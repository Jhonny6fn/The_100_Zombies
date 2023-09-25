using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cuenta_Atras : MonoBehaviour
{
    public float currentTime = 2f;
    public float startingTime = 10f;

    [SerializeField] Text CuentaAtras;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        CuentaAtras.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);
        }
    }
}
