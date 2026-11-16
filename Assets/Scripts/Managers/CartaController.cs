using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CartaController : MonoBehaviour
{
    [Header("Narración")]
    public AudioSource narracionAudio;
    public TMP_Text textoNarracion;

    [Header("Botones")]
    public GameObject botonReleer;
    public GameObject botonContinuar;

    [Header("Escena siguiente")]
    public string siguienteEscena = "Playground";

    private void Start()
    {
        botonReleer.SetActive(false);
        botonContinuar.SetActive(false);

        narracionAudio.Play();
        StartCoroutine(EsperarNarracion());
    }

    private System.Collections.IEnumerator EsperarNarracion()
    {
        yield return new WaitWhile(() => narracionAudio.isPlaying);

        botonReleer.SetActive(true);
        botonContinuar.SetActive(true);
    }

    public void Releer()
    {
        botonReleer.SetActive(false);
        botonContinuar.SetActive(false);

        narracionAudio.Stop();
        narracionAudio.Play();

        StartCoroutine(EsperarNarracion());
    }

    public void Continuar()
    {
        SceneManager.LoadScene(siguienteEscena);
    }
}