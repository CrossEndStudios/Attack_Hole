using UnityEngine;

public class CameraColorChange : MonoBehaviour
{
    public Color startColor;
    public Color endColor;
    public float duration;

    private Camera cameraComponent;
    private float startTime;

    void Start()
    {
        cameraComponent = GetComponent<Camera>();
        startTime = Time.time;
    }

    void Update()
    {
        float timeSinceStart = Time.time - startTime;
        float t = Mathf.Clamp01(timeSinceStart / duration);
        cameraComponent.backgroundColor = Color.Lerp(startColor, endColor, t);
    }
}
