using UnityEngine.UI;
using UnityEngine;

using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour 
{
	public float health = 100f;
	public float resetAfterDeathTime = 5f;
	public AudioClip deathClip;
	public Canvas deathCanvas;
	public Canvas playerInfoCanvas;
	public Slider healthSlider;
	public Image healthBar;

	private FirstPersonController playerMovement;
	private LastPlayerSighting lastPlayerSighting;
	private float timer;
	private bool playerDead;

	void Awake()
	{
		deathCanvas.enabled = false;
		playerMovement = GetComponent<FirstPersonController>();
		//lastPlayerSighting = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<LastPlayerSighting>();
	}

	void Update()
	{
		healthSlider.value = health;
		if(health < 0) health = 0;
		if(health == 0f)
		{
			PlayerDead();
		}
		if(health < 50)
			healthBar.color = Color.yellow;
		if(health < 20)
			healthBar.color = Color.red;
	}
	void PlayerDead(){
		playerInfoCanvas.enabled = false;
		deathCanvas.enabled = true;
		Debug.Log("You died !!!");
		//AudioSource.PlayClipAtPoint(deathClip, transform.position);
		//lastPlayerSighting.position = lastPlayerSighting.resetPosition;
	}
	
	public void TakeDamage(float amount)
	{
		health -= amount;
	}

}
