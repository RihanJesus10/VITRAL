using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject painelPause;
    private bool pausado = false;

    private bool fimJogo = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        painelPause.SetActive(false); //começa desligado
    }

    public void CarregarCenaPorNome(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
        painelPause.SetActive(false);

        if (pausado == true)
        {
            Time.timeScale = 1f;
        }
    }

    private void Update()

    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PausarOuDespausar();
        }
    }

    public void Restart(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
        if(pausado == true)
        {
            Time.timeScale = 1f;
        }
    }

    public void PausarOuDespausar()
    {
        pausado = !pausado;

        if (pausado)
        {
            Time.timeScale = 0f;
            painelPause.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            painelPause.SetActive(false) ;
        }
    }

  public void Sair()
    {
        Application.Quit();
    }

}
