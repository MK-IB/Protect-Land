using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour 
{
	int bulletNum;
	int maxBulletNum = 30;
	
	public Text bulletNumText;
	public ParticleSystem muzzle;
	public AudioClip firing;
	public AudioClip reloading;

	private Camera cam;
	private EnemyHealth enemyHealth;
	private float damageAmount = 13f;
	
	void Start()
	{
		bulletNum = maxBulletNum;
		cam = Camera.main;
	}
	void Update()
	{
		bulletNumText.text = bulletNum.ToString();
		if(Input.GetButtonDown("Fire1") && bulletNum > 0)
		{
			//Debug.Log("Player firinggg..");
			Shoot();
		}
		//RELOADING
		if(Input.GetKeyDown(KeyCode.R)) 
			Reload();
	}
	void Shoot()
	{
		RaycastHit hit;
		if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
		{
			EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
			if(enemyHealth != null)
				enemyHealth.TakeDamage(damageAmount);
		}
		bulletNum -= 1;
		ShotEffects(hit);

	}
	void ShotEffects(RaycastHit hit)
	{
		AudioSource.PlayClipAtPoint(firing, transform.position);
		muzzle.Play();
	}

	void Reload()
	{
		if(bulletNum < maxBulletNum)
		{
			bulletNum = maxBulletNum;
			AudioSource.PlayClipAtPoint(reloading, transform.position);
		}
	}
}
