using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cambio_Arma : MonoBehaviour
{
    public GameObject Arma1;
    public GameObject Arma2;
    public GameObject Arma3;
    public TextMeshProUGUI AmmoInfo;

    // Start is called before the first frame update
    void Start()
    {
        Arma1.SetActive(true);
        Arma2.SetActive(false);
        Arma3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RayCastShootComplete currentGun = FindObjectOfType<RayCastShootComplete>();
        AmmoInfo.text = currentGun.currentAmmo + " / " + currentGun.magazineSize;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Arma1.SetActive(true);
            Arma2.SetActive(false);
            Arma3.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Arma1.SetActive(false);
            Arma2.SetActive(true);
            Arma3.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Arma1.SetActive(false);
            Arma2.SetActive(false);
            Arma3.SetActive(true);
        }
    }
}
