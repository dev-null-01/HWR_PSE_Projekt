using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

/// <summary>
/// WorldBoundsHandler — Safety-Net für VR-Interactables.
/// Platziere dieses Skript auf dem WorldBounds-GameObject (Box-Collider, IsTrigger = true).
/// </summary>
public class WorldBoundsHandler : MonoBehaviour
{
    [Header("Einstellungen")]
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private string interactablesLayerName = "Interactables";

    [Tooltip("Kleiner zufälliger Versatz beim Respawn, damit gestapelte Objekte nicht exakt übereinander landen.")]
    [SerializeField] private float spawnSpread = 0.15f;

    [Tooltip("Wie lange ein Objekt nach dem Reset gesperrt bleibt (verhindert Endlosschleifen).")]
    [SerializeField] private float resetCooldown = 0.5f;

    // Objekte, die gerade zurückgesetzt werden – kein Doppel-Trigger möglich
    private readonly HashSet<GameObject> _objectsInReset = new HashSet<GameObject>();

    private int _interactablesLayer = -1;

    private void Awake()
    {
        _interactablesLayer = LayerMask.NameToLayer(interactablesLayerName);

        if (_interactablesLayer == -1)
            Debug.LogError($"[WorldBounds] Layer '{interactablesLayerName}' nicht gefunden! Bitte Layer anlegen.");

        if (respawnPoint == null)
            Debug.LogError("[WorldBounds] Kein RespawnPoint zugewiesen!");
    }

    private void OnTriggerExit(Collider other)
    {
        // Falscher Layer → ignorieren
        if (other.gameObject.layer != _interactablesLayer) return;

        // Bereits im Reset → ignorieren (Endlosschleifen-Schutz)
        if (_objectsInReset.Contains(other.gameObject)) return;

        StartCoroutine(RespawnRoutine(other.gameObject));
    }

    private IEnumerator RespawnRoutine(GameObject obj)
    {
        // Sofort sperren, bevor irgendwas anderes passiert
        _objectsInReset.Add(obj);

        Rigidbody rb = obj.GetComponent<Rigidbody>();
        XRBaseInteractable interactable = obj.GetComponent<XRBaseInteractable>();

        // ── SCHRITT 1: Socket-Check ────────────────────────────────────────────
        // Wenn das Objekt in einem Socket steckt → ABBRUCH.
        // (SelectExit auf einem Socket friert das Objekt ein und verhindert
        //  späteres Herausnehmen.)
        if (interactable != null && interactable.isSelected)
        {
            if (IsHeldBySocket(interactable))
            {
                Debug.Log($"[WorldBounds] {obj.name} ist in einem Socket – Reset abgebrochen.");
                _objectsInReset.Remove(obj);
                yield break;
            }
        }

        // ── SCHRITT 2: Hand-Griff lösen ───────────────────────────────────────
        // Nur wenn eine HAND (kein Socket) das Objekt hält.
        if (interactable != null && interactable.isSelected)
        {
            // Kopie der Liste, da SelectExit die Original-Liste verändert
            var interactorsCopy = new List<IXRSelectInteractor>(interactable.interactorsSelecting);
            foreach (var interactor in interactorsCopy)
            {
                interactable.interactionManager.SelectExit(interactor, interactable);
            }

            // Einen Frame warten, damit XRI den State sauber abschließt
            yield return null;
        }

        // ── SCHRITT 3: Physik sofort einfrieren ───────────────────────────────
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.linearVelocity   = Vector3.zero;
            rb.angularVelocity  = Vector3.zero;
        }

        // ── SCHRITT 4: Teleport ───────────────────────────────────────────────
        Vector3 randomOffset = new Vector3(
            Random.Range(-spawnSpread, spawnSpread),
            0f,
            Random.Range(-spawnSpread, spawnSpread)
        );
        obj.transform.SetPositionAndRotation(
            respawnPoint.position + randomOffset,
            respawnPoint.rotation
        );

        // ── SCHRITT 5: Vollbremsung über mehrere Fixed-Frames ─────────────────
        // Killt jegliche "gespeicherte" Wucht, die Unity intern noch hält.
        for (int i = 0; i < 5; i++)
        {
            if (rb != null)
            {
                rb.linearVelocity  = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
            yield return new WaitForFixedUpdate();
        }

        // ── SCHRITT 6: Physik freigeben ───────────────────────────────────────
        if (rb != null)
        {
            rb.isKinematic     = false;
            rb.linearVelocity  = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        Debug.Log($"[WorldBounds] {obj.name} erfolgreich zurückgesetzt.");

        // ── SCHRITT 7: Cooldown, dann Sperre aufheben ─────────────────────────
        yield return new WaitForSeconds(resetCooldown);
        _objectsInReset.Remove(obj);
    }

    /// <summary>
    /// Gibt true zurück, wenn das Interactable von einem XRSocketInteractor gehalten wird.
    /// Prüft alle aktuellen Interactors; ein Socket erbt von XRSocketInteractor.
    /// </summary>
    private static bool IsHeldBySocket(XRBaseInteractable interactable)
    {
        foreach (var interactor in interactable.interactorsSelecting)
        {
            if (interactor is XRSocketInteractor)
                return true;
        }
        return false;
    }
}