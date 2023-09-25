using UnityEngine;
using System.Collections;

public class RayCastShootComplete : MonoBehaviour {

	public int gunDamage = 1;
	public float fireRate = 0.25f;
	public float weaponRange = 40f;
	public float hitForce = 100f;
	public Transform gunEnd;
	private bool isShooting;

	private Camera fpsCam;
	private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
	//public AudioSource gunAudio;
	private LineRenderer laserLine;
	private float nextFire;

	public int currentAmmo;
	public int maxAmmo = 10;
	public int magazineSize = 30;
	public int ammoToRest = 2;
	public float reloadTime = 2f;
	private bool isReloading;
	public Animator myAnim;

	[SerializeField] private AudioClip sonidoDisparo;
	[SerializeField] private AudioClip sonidoRecargar;
	private AudioSource m_AudioSource;

	void Start () 
	{
		laserLine = GetComponent<LineRenderer>();

		m_AudioSource = GetComponent<AudioSource>();

		fpsCam = GetComponentInParent<Camera>();

		currentAmmo = maxAmmo;

		myAnim = GetComponent<Animator>();
	}
	
	void Update () 
	{
		if (currentAmmo == 0 && magazineSize == 0)
        {
			return;
        }

		if (isReloading)
        {
			return;
        }

		if (currentAmmo == 0 && !isReloading)
        {
			StartCoroutine(Reload());
        }

		/*
		if (Input.GetKeyDown(KeyCode.R))
        {
			StartCoroutine(Reload2());
		}
		*/

		if (Input.GetButtonDown("Fire1") && Time.time > nextFire && !isShooting) 
		{
			nextFire = Time.time + fireRate;

            StartCoroutine(ShotEffect());

            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f));

            RaycastHit hit;

			laserLine.SetPosition (0, gunEnd.position);

			currentAmmo--;

			if (Physics.Raycast (rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
			{
				laserLine.SetPosition (1, hit.point);

				ShootableBox health = hit.collider.GetComponent<ShootableBox>();

				if (health != null)
				{
					health.Damage (gunDamage);
				}

				if (hit.rigidbody != null)
				{
					hit.rigidbody.AddForce (-hit.normal * hitForce);
				}
			}
			else
			{
                laserLine.SetPosition (1, rayOrigin + (fpsCam.transform.forward * weaponRange));
			}
		}
	}

	private IEnumerator ShotEffect()
	{
		isShooting = true;
		myAnim.SetBool("isShooting", true);

		m_AudioSource.clip = sonidoDisparo;
		m_AudioSource.Play();

		laserLine.enabled = true;

		yield return shotDuration;
		myAnim.SetBool("isShooting", false);

		laserLine.enabled = false;
		isShooting = false;
	}

	public IEnumerator Reload()
    {
		isReloading = true;
		myAnim.SetBool("isReloading", true);

		m_AudioSource.clip = sonidoRecargar;
		m_AudioSource.Play();

		yield return new WaitForSeconds(reloadTime);
		myAnim.SetBool("isReloading", false);
		if (magazineSize >= maxAmmo)
        {
			currentAmmo = maxAmmo;
			magazineSize -= maxAmmo;
		}
        else
        {
			currentAmmo = magazineSize;
			magazineSize = 0;
        }
		isReloading = false;
    }

	/*
	IEnumerator Reload2()
    {
		isReloading = true;
		myAnim.SetBool("isReloading", true);

		m_AudioSource.clip = sonidoRecargar;
		m_AudioSource.Play();

		yield return new WaitForSeconds(reloadTime);
		myAnim.SetBool("isReloading", false);
		if (magazineSize >= maxAmmo)
		{
			maxAmmo -= currentAmmo = ammoToRest;
			magazineSize -= ammoToRest;
			currentAmmo = maxAmmo;
		}
		else
		{
			currentAmmo = magazineSize;
			magazineSize = 0;
		}
		isReloading = false;
	}
	*/
}