using UnityEngine;

public class LifePowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // pega o gerenciador de vidas
            Vidro vidaManager = FindAnyObjectByType<Vidro>();

            if (vidaManager != null)
            {
                // só recupera se não estiver com a vida cheia
                if (vidaManager.GetVidasAtuais() < vidaManager.maxVidas)
                {
                    vidaManager.GanharVida(1);

                    // some com o powerup depois de pegar
                    Destroy(gameObject);
                }
            }
        }
    }
}
