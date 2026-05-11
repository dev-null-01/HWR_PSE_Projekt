using UnityEngine;
using System.Collections;

public class GlobalBlinker : MonoBehaviour
{
    [Header("Reihenfolge in der Liste: 2x Oben, dann 2x Unten!")]
    public SkinnedMeshRenderer[] eyePlanes;

    [Header("Timing")]
    public float minWait = 2f;
    public float maxWait = 6f;
    
    [Header("Gesicht-Timing")]
    public float minFaceWait = 3f;
    public float maxFaceWait = 10f;


    private float currentTopWeight = 0f;
    private float currentBottomWeight = 0f;

    void Start()
    {
        StartCoroutine(BlinkRoutine());
        StartCoroutine(FaceChangeRoutine());
    }

    // --- LOGIK 1: ZUFÄLLIGE GESICHTER ---
    IEnumerator FaceChangeRoutine()
    {
        while (true)
        {
            int faceType = Random.Range(0, 4); 

            switch (faceType)
            {
                case 0: // Standard
                    currentTopWeight = 0; currentBottomWeight = 0; break;
                case 1: // Schläfrig
                    currentTopWeight = 60; currentBottomWeight = 60; break;
                case 2: // Fokussiert/Böse
                    currentTopWeight = 80; currentBottomWeight = 0; break;
                case 3: // Skeptisch
                    currentTopWeight = 0; currentBottomWeight = 70; break;
            }

            ApplyCurrentFace();
                yield return new WaitForSeconds(Random.Range(minFaceWait, maxFaceWait));

        }
    }

    // --- LOGIK 2: BLINZELN (Überlagert das Gesicht kurz) ---
    IEnumerator BlinkRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(minWait, maxWait);
            yield return new WaitForSeconds(waitTime);
            
            SetAllWeights(100f); // Augen zu
            yield return new WaitForSeconds(0.12f);
            
            ApplyCurrentFace(); // Zurück zum Gesichtsausdruck
        }
    }

    void ApplyCurrentFace()
    {
        for (int i = 0; i < eyePlanes.Length; i++)
        {
            if (eyePlanes[i] == null) continue;
            
            // Die ersten zwei (0,1) sind OBEN, der Rest (2,3) ist UNTEN
            float weight = (i < 2) ? currentTopWeight : currentBottomWeight;
            eyePlanes[i].SetBlendShapeWeight(0, weight);
        }
    }

    void SetAllWeights(float weight)
    {
        foreach (var smr in eyePlanes)
        {
            if (smr != null) smr.SetBlendShapeWeight(0, weight);
        }
    }
}
