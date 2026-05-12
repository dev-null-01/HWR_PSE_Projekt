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
    [Range(1f, 20f)] public float smoothSpeed = 10f;

    [Header("Audio Setup")]
    public AudioClip defaultVoiceClip; 

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
            targetWeight = finalDefaultValue;
        }

        currentWeight = Mathf.Lerp(currentWeight, targetWeight, Time.deltaTime * smoothSpeed);
        meshRenderer.SetBlendShapeWeight(index, Mathf.Clamp(currentWeight, 0, 100));
    }

    public void PlaySpecificVoice(AudioClip newClip)
    {
        if (audioSource != null && newClip != null)
        {
            // Die "Sperre": Nur abspielen, wenn gerade Ruhe ist
            if (!audioSource.isPlaying) 
            {
                audioSource.clip = newClip;
                audioSource.Play();
                Debug.Log("Spiele Clip: " + newClip.name);
            }
            else 
            {
                Debug.Log("Roboter redet noch, Button ignoriert.");
            }
        }
    }

    public void PlayRobotVoice() 
    {
        PlaySpecificVoice(defaultVoiceClip);
    }
}