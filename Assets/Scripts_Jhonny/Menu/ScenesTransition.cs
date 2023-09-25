using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesTransition : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void Juego1()
    {
        SceneManager.LoadScene("Map_v1");
    }

    public void Juego2()
    {
        SceneManager.LoadScene("Mapa_2");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("RayCastShootComplete");
    }

    public void SalirJuego()
    {
        Application.Quit();
    }
}
