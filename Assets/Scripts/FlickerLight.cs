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
        // Ändert die Helligkeit in jedem Frame zufällig
        lightSource.intensity = Random.Range(minIntensity, maxIntensity);
    }
}