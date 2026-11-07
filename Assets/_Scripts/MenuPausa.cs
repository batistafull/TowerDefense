using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject canvasMenuPausa;
    public bool juegoPausado;

    void Start()
    {
        Time.timeScale = 1;
        juegoPausado = false;
        canvasMenuPausa.SetActive(false);
    }

    public void Pausar()
    {
        juegoPausado = true;
        Time.timeScale = 0;
        canvasMenuPausa.SetActive(true);
    }

    public void Reanudar()
    {
        juegoPausado = false;
        Time.timeScale = 1;
        canvasMenuPausa.SetActive(false);
    }

    public void ReintentarNivel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CargarMenuPrincipal()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }
}
