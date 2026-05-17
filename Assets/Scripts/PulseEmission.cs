using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class PulseEmission : MonoBehaviour
{
    [Header("Einstellungen")]
    public Color pulseColor = new Color(0.902f, 1f, 0f); // #E6FF00

    [Range(0.1f, 5f)]
    public float speed = 1f;

    [Range(0f, 6f)]
    public float maxIntensity = 3f;

    private Material _mat;
    private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");

    private void Awake()
    {
        _mat = GetComponent<Renderer>().material;
        _mat.EnableKeyword("_EMISSION");
        _mat.SetFloat("_EmissionEnabled", 1f);
        _mat.SetColor(EmissionColor, pulseColor);
    }

    private void Update()
    {
        float t = (Mathf.Sin(Time.time * speed) + 1f) * 0.5f;
        _mat.SetColor(EmissionColor, pulseColor * (t * maxIntensity));
    }

    private void OnDestroy()
    {
        if (_mat != null) Destroy(_mat);
    }
}