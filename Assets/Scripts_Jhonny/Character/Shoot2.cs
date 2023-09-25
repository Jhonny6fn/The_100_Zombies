using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot2 : MonoBehaviour
{
	public int gunDamage = 1;
	public float fireRate = 0.25f;
	public float weaponRange = 40f;
	public float hitForce = 100f;
	public Transform gunEnd;
	private bool isShooting;

	private Camera fpsCam;
	private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
	private LineRenderer laserLine;
	private float nextFire;

	public Animator myAnim;

	[SerializeField] private AudioClip sonidoDisparo;
	private AudioSource m_AudioSource;

	void Start()
	{
		laserLine = GetComponent<LineRenderer>();

		m_AudioSource = GetComponent<AudioSource>();

		fpsCam = GetComponentInParent<Camera>();

		myAnim = GetComponent<Animator>();
	}

	void Update()
	{
		if (Input.GetButtonDown("Fire1") && Time.time > nextFire && !isShooting)
		{
			nextFire = Time.time + fireRate;

			StartCoroutine(ShotEffect());

			Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

			RaycastHit hit;

			laserLine.SetPosition(0, gunEnd.position);

			if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
			{
				laserLine.SetPosition(1, hit.point);

				ShootableBox health = hit.collider.GetComponent<ShootableBox>();

				if (health != null)
				{
					health.Damage(gunDamage);
				}

				if (hit.rigidbody != null)
				{
					hit.rigidbody.AddForce(-hit.normal * hitForce);
				}
			}
			else
			{
				laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
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
}
