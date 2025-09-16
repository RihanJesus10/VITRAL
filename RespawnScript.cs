using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject respawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Move o player pro respawn
            Player.transform.position = respawnPoint.transform.position;

            // Reseta velocidade do Rigidbody2D pra evitar cair de novo
            Rigidbody2D rb = Player.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.linearVelocity = Vector2.zero;

            // Faz o player perder 1 vida
            FindAnyObjectByType<Vidro>().PerderVida(1);
        }
    }
}
