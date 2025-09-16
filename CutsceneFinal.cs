using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CutsceneFinal : MonoBehaviour
{
    public VideoPlayer cutscene1;
    public VideoPlayer cutscene2;
    public string MainMenu = "Menu"; 

    private bool cutsceneAtiva = false;
    private bool podeVoltar = false;

    private void Start()
    {
        
        if (cutscene1 != null) cutscene1.gameObject.SetActive(false);
        if (cutscene2 != null) cutscene2.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !cutsceneAtiva)
        {
            cutsceneAtiva = true;
            IniciarCutsceneAleatoria();
        }
    }

    private void IniciarCutsceneAleatoria()
    {
        
        int escolha = Random.Range(0, 2);
        VideoPlayer selecionado = (escolha == 0) ? cutscene1 : cutscene2;

        
        selecionado.gameObject.SetActive(true);

        
        selecionado.loopPointReached -= OnCutsceneFim;
        selecionado.loopPointReached += OnCutsceneFim;

        
        selecionado.Play();

        Debug.Log($"Reproduzindo cutscene {escolha + 1}");
    }

    private void OnCutsceneFim(VideoPlayer vp)
    {
        Debug.Log("fimdacutscene");
        podeVoltar = true;
       
        vp.Pause();
    }

    private void Update()
    {
        
        if (cutsceneAtiva && podeVoltar && Input.anyKeyDown)
        {
            Debug.Log("menu");
            SceneManager.LoadScene(MainMenu);
        }
    }

    
    private void OnDestroy()
    {
        if (cutscene1 != null)
            cutscene1.loopPointReached -= OnCutsceneFim;
        if (cutscene2 != null)
            cutscene2.loopPointReached -= OnCutsceneFim;
    }
}