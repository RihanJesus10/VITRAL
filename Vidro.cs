using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Vidro : MonoBehaviour
{
    public int maxVidas = 3;
    private int vidasAtuais;

    [Header("UI das vidas")]
    public Image hudVidas;
    public Sprite[] estadosVidas;

    [Header("Tela de Game Over")]
    public GameObject gameOverCanvas; // arrasta o Canvas aqui no Inspector

    void Start()
    {
        vidasAtuais = maxVidas;
        AtualizarVidas();

        if (gameOverCanvas != null)
            gameOverCanvas.SetActive(false); // começa desativado
    }

    public void PerderVida(int quantidade)
    {
        vidasAtuais -= quantidade;
        if (vidasAtuais < 0) vidasAtuais = 0;

        AtualizarVidas();

        if (vidasAtuais <= 0)
        {
            GameOver();
        }
    }

    void AtualizarVidas()
    {
        int index = maxVidas - vidasAtuais;
        index = Mathf.Clamp(index, 0, estadosVidas.Length - 1);
        hudVidas.sprite = estadosVidas[index];
    }

    public int GetVidasAtuais()
    {
        return vidasAtuais;
    }

    public void GanharVida(int quantidade)
    {
        vidasAtuais += quantidade;
        if (vidasAtuais > maxVidas) vidasAtuais = maxVidas;
        AtualizarVidas();
    }

    void GameOver()
    {

        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
            Time.timeScale = 0f; // pausa só depois de ativar
        }
    }

    // Chama esse método no botão Restart
    public void RestartLevel()
    {
        Time.timeScale = 1f; // volta ao normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

