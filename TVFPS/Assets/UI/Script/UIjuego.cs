using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIjuego : MonoBehaviour {
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject Jugador;
    public GameObject JuegoUI;





    void Start()
    {

        PauseMenuUI.SetActive(false);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Jugador.SetActive(true);
        JuegoUI.SetActive(true);

        Time.timeScale = 1f;
        GameIsPaused = false;

    }
    public void Pause()
    {
        Jugador.SetActive(false);
        JuegoUI.SetActive(false);
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void CargarMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void QuitarJuego()
    {
        Application.Quit();

    }
}

