using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Volver_al_menu : MonoBehaviour
{
    public void VolverMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}