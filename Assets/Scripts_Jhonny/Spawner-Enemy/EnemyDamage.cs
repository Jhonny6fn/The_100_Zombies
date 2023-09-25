using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "FPSController")
        {
            collision.gameObject.GetComponent<Health_Scrip>().Vida = collision.gameObject.GetComponent<Health_Scrip>().Vida - 1;
        }
    }
}
