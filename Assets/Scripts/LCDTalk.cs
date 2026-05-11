using UnityEngine;

public class LCDTalk : MonoBehaviour
{
    public AudioSource audioSource;
    public SkinnedMeshRenderer meshRenderer;
    public string shapeKeyName = "Mouth Regulator";
    
    [Header("Tuning")]
    public float sensitivity = 500f;
    public float silentRestValue = 70f;  
    public float finalDefaultValue = 30f; 
    [Range(1f, 20f)] public float smoothSpeed = 10f; // Wie schnell er gleitet

    private float currentWeight = 30f;

    void Update()
    {
        int index = meshRenderer.sharedMesh.GetBlendShapeIndex(shapeKeyName);
        if (index == -1) return;

        float targetWeight;

        if (audioSource != null && audioSource.isPlaying)
        {
            float[] samples = new float[256];
            audioSource.GetOutputData(samples, 0);
            
            float volume = 0;
            foreach (float s in samples) volume += Mathf.Abs(s);
            volume /= 256;

            targetWeight = silentRestValue - (volume * sensitivity);
        }
        else
        {
            // Wenn fertig: Ziel ist 30
            targetWeight = finalDefaultValue;
        }

        // --- DER SMOOTH-TRICK ---
        // Berechnet einen weichen Übergang vom aktuellen Wert zum Zielwert
        currentWeight = Mathf.Lerp(currentWeight, targetWeight, Time.deltaTime * smoothSpeed);
        
        meshRenderer.SetBlendShapeWeight(index, Mathf.Clamp(currentWeight, 0, 100));
    }
}
