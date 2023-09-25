using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health_Scrip : MonoBehaviour
{
    public float Vida;
    public Slider barraVida;

    void Update()
    {
        barraVida.value = Vida;
        if (Vida <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Menu",LoadSceneMode.Single);
        }
    }
}
