using UnityEngine;
using System.Collections;

public class JumpPowerUp : MonoBehaviour
{
    public float boostedJump = 20f; // valor de pulo com boost
    public float duration = 5f;     // tempo do efeito

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                StartCoroutine(ApplyJumpBoost(player));
            }
        }
    }

    private IEnumerator ApplyJumpBoost(PlayerController player)
    {
        float originalJump = player.jump; // guarda o valor original
        player.jump = boostedJump;        // aumenta o pulo temporariamente

        // desabilita o powerup visualmente
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(duration);

        player.jump = originalJump; // volta ao normal

        Destroy(gameObject); // apaga o power-up
    }
}
