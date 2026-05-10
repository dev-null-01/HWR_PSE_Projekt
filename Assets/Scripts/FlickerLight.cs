using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    private Light lightSource;
    public float minIntensity = 2f;
    public float maxIntensity = 7f;

    void Start()
    {
        lightSource = GetComponent<Light>();
    }

    void Update()
{
    if (Random.value > 0.9f) // Nur in 10% der Zeit passiert etwas
    {
        lightSource.intensity = Random.Range(minIntensity, maxIntensity);
    }
}
}