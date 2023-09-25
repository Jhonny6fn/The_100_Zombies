using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    public float primero;
    public float repeticiones;

    void Start()
    {
        InvokeRepeating("spawnenemy", primero, repeticiones);
    }

    private void spawnenemy()
    {
        Instantiate(Enemy, transform.position, transform.rotation);
    }
}
