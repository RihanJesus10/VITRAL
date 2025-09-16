using UnityEngine;

public class FloatEffect : MonoBehaviour
{
    public float amplitude = 0.5f; // altura do movimento
    public float speed = 2f;       // velocidade do movimento

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float y = Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = startPos + new Vector3(0, y, 0);
    }
}
