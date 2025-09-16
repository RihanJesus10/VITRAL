using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System.Collections;

public class CutsceneManager : MonoBehaviour
{
    [Header("Textos da cutscene")]
    public TextMeshProUGUI textoUI;
    [TextArea]
    public string[] falas; // lista de falas
    private int falaAtual = 0;

    [Header("Vídeo")]
    public GameObject videoPlayerObject; // objeto que contém o VideoPlayer
    private VideoPlayer videoPlayer;

    [Header("Configuração")]
    public string proximaCena = "GameScene"; // nome da cena do jogo
    public float fadeDuration = 1f;          // tempo do fade in/out

    private bool mostrandoTexto = true;
    private bool podeAvancar = false;

    void Start()
    {
        if (falas.Length > 0 && textoUI != null)
        {
            StartCoroutine(MostrarTextoComFade(falas[0]));
        }

        if (videoPlayerObject != null)
        {
            videoPlayer = videoPlayerObject.GetComponent<VideoPlayer>();
            videoPlayerObject.SetActive(false);
            videoPlayer.loopPointReached += OnVideoFim;
        }
    }

    void Update()
    {
        if (mostrandoTexto && podeAvancar && Input.GetKeyDown(KeyCode.Space))
        {
            AvancarTexto();
        }
    }

    void AvancarTexto()
    {
        falaAtual++;
        if (falaAtual < falas.Length)
        {
            StartCoroutine(MostrarTextoComFade(falas[falaAtual]));
        }
        else
        {
            // acabou os textos -> inicia vídeo
            mostrandoTexto = false;
            textoUI.gameObject.SetActive(false);

            if (videoPlayerObject != null)
            {
                videoPlayerObject.SetActive(true);
                videoPlayer.Play();
            }
            else
            {
                SceneManager.LoadScene(proximaCena);
            }
        }
    }

    IEnumerator MostrarTextoComFade(string novaFala)
    {
        podeAvancar = false;

        // fade out
        yield return StartCoroutine(FadeTexto(1f, 0f));

        // troca o texto
        textoUI.text = novaFala;

        // fade in
        yield return StartCoroutine(FadeTexto(0f, 1f));

        podeAvancar = true;
    }

    IEnumerator FadeTexto(float inicio, float fim)
    {
        float t = 0f;
        Color cor = textoUI.color;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(inicio, fim, t / fadeDuration);
            textoUI.color = new Color(cor.r, cor.g, cor.b, alpha);
            yield return null;
        }

        textoUI.color = new Color(cor.r, cor.g, cor.b, fim);
    }

    void OnVideoFim(VideoPlayer vp)
    {
        SceneManager.LoadScene(proximaCena);
    }
}
