using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ColorPulse : MonoBehaviour
{
    public Gradient Gradient;
    public bool Pulsing = true;
    public float PulseSpeed = 1;
    public float PulseCycleDelay = 0f;
    private SpriteRenderer _sr;
    private float _progress;

    void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
       if (!Pulsing || Gradient == null) return;

        // Get ping-pong time: goes 0→1→0 continuously
        float t = Mathf.PingPong(Time.time * PulseSpeed, 1f);

        // If you want a delay at each end, you can remap `t`:
        if (PulseCycleDelay > 0f)
        {
            float cycleLength = 1f + (PulseCycleDelay * PulseSpeed); 
            float raw = Mathf.PingPong(Time.time * PulseSpeed, cycleLength);
            t = Mathf.Clamp01(raw); // holds at 0 or 1 during the delay
        }

        _sr.color = Gradient.Evaluate(t);
    }


    void OnValidate()
    {
        if (_sr == null) _sr = GetComponent<SpriteRenderer>();
        if (_sr != null && Gradient != null)
            _sr.color = Gradient.Evaluate(Mathf.Clamp01(_progress));
    }
}
