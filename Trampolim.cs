using UnityEngine;

public class Trampolim : MonoBehaviour
{
    public float bounceForce = 15f; // força do pulo

    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            // zera a velocidade pra nAo acumular
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);

            // aplica impulso pra cima
            rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
        }
    }
}
