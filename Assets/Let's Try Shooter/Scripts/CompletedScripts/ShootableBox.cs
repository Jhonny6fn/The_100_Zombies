using UnityEngine;
using System.Collections;

public class ShootableBox : MonoBehaviour {

	public int currentHealth = 3;
	private Animator myAnimator;

    private void Start()
    {
		myAnimator = GetComponent<Animator>();
	}

    public void Damage(int damageAmount)
	{
		currentHealth -= damageAmount;

		if (currentHealth <= 0) 
		{
			AnimacionMuerte();
		}
	}

	public void AnimacionMuerte()
    {
		myAnimator.Play("Z_FallingBack");
    }

	public void destruirObjeto()
	{
		Destroy(gameObject);
	}

	public void ContadorMuerte()
    {
		UIManager2.instance.killCount++;
		UIManager2.instance.UpdateKillCounterUI();
	}
}
