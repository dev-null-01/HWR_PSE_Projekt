using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class AutoReset : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;
    private XRGrabInteractable interactable;

    [SerializeField] private float resetDelay = 15f; // Hier kannst du die Zeit im Editor einstellen

    void Start()
    {
        startPosition = transform.localPosition;
        startRotation = transform.localRotation;
        
        interactable = GetComponent<XRGrabInteractable>();
        interactable.selectExited.AddListener(OnRelease);
        
        // Sicherheitshalber: Falls man sie greift, Reset abbrechen
        interactable.selectEntered.AddListener(OnGrab);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        // Falls der Timer läuft, während wir sie wieder greifen: STOPP!
        CancelInvoke("ResetObject");
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        // Erst alten Timer löschen, damit sie sich nicht stapeln
        CancelInvoke("ResetObject");
        // Neuen Timer starten
        Invoke("ResetObject", resetDelay);
    }

    private void ResetObject()
    {
        if (!interactable.isSelected)
        {
            transform.localPosition = startPosition;
            transform.localRotation = startRotation;
            
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
            Debug.Log(gameObject.name + " wurde automatisch zurückgesetzt.");
        }
    }
}