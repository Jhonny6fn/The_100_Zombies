using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cuenta_Adelante : MonoBehaviour
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
        currentTime += 1 * Time.deltaTime;
        CuentaAtras.text = currentTime.ToString("0");
    }
}
