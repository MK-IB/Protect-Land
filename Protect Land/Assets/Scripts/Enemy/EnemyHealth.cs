using UnityEngine;

public class EnemyHealth : MonoBehaviour 
{
	private float health = 100;

	void Update()
	{
		if(health <= 0)
			EnemyDead();
			
	}

	public void TakeDamage(float damage)
	{
		health -= damage;
	}
	void EnemyDead()
	{
		Destroy(gameObject);
	}
}
