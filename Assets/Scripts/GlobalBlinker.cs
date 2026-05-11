using UnityEngine;
using System.Collections;

public class GlobalBlinker : MonoBehaviour
{
    [Header("Die 4 Blenden-Objekte (Einfach reinziehen)")]
    public SkinnedMeshRenderer[] eyePlanes;

    [Header("Timing")]
    public float minWait = 2f;
    public float maxWait = 6f;

    void Start()
    {
        // Wir starten die Endlos-Schleife
        StartCoroutine(BlinkRoutine());
    }

    IEnumerator BlinkRoutine()
    {
        while (true)
        {
            // Echter Zufall für die Wartezeit
            float waitTime = Random.Range(minWait, maxWait);
            yield return new WaitForSeconds(waitTime);
            
            // Augen zu (Wir nehmen Index 0, da jede Plane nur einen Regler hat)
            SetAllWeights(100f);
            yield return new WaitForSeconds(0.12f); // Dauer des geschlossenen Auges
            
            // Augen auf
            SetAllWeights(0f);
        }
    }

    void SetAllWeights(float weight)
    {
        foreach (var smr in eyePlanes)
        {
            if (smr != null && smr.sharedMesh.blendShapeCount > 0)
            {
                // Da jede Plane nur GENAU EINEN Regler hat, 
                // steuern wir einfach immer den ersten Regler (Index 0) an.
                // Das spart das Tippen der Namen!
                smr.SetBlendShapeWeight(0, weight);
            }
        }
    }
}
