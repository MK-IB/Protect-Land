using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
	public float minimumDamage = 5f;
	public AudioClip shotClip;
	public float flashIntensity = 3f;
	public float fadeSpeed = 10f;

	private Animator anim;
	private HashIDs hash;
	private LineRenderer laserShotLine;
	private Light laserShotLight;
	private SphereCollider col;
	private Transform player;
	private PlayerHealth playerHealth;
	private bool shooting;
	private float scaledDamage;

	void Awake()
	{
		anim = GetComponent<Animator>();
		laserShotLine = GetComponentInChildren<LineRenderer>();
		laserShotLight = laserShotLine.gameObject.GetComponent<Light>();
		col =GetComponent<SphereCollider>();
		player = GameObject.FindGameObjectWithTag(Tags.player).transform;
		playerHealth = player.gameObject.GetComponent<PlayerHealth>();
		hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();

		laserShotLine.enabled = false;
		laserShotLight.intensity = 0f;
	}

	void Update()
	{
		float shot = anim.GetFloat(hash.shotFloat);
		if(shot > 0.5f && !shooting)
			Shoot();
		if(shot < 0.5f)
		{
			shooting = false;
			laserShotLine.enabled = false;
		}
		laserShotLight.intensity = Mathf.Lerp(laserShotLight.intensity, 0, fadeSpeed * Time.deltaTime);
	}

	void OnAnimatorIK(int layerIndex)
	{
		float aimWeight = anim.GetFloat(hash.aimWeightFloat);
		anim.SetIKPosition(AvatarIKGoal.RightHand, player.position + Vector3.up * 1.5f);
		anim.SetIKPositionWeight(AvatarIKGoal.RightHand, aimWeight);
	}
	void Shoot()
	{
		shooting = true;
		//float fractionalDistance = (col.radius -Vector3.Distance(transform.position, player.position)) / col.radius;
		//float damage = fractionalDistance + minimumDamage;
		//damage = Mathf.CeilToInt(damage);
		playerHealth.TakeDamage(minimumDamage);
		ShotEffects();
	}
	void ShotEffects()
	{
		laserShotLine.SetPosition(0, laserShotLine.transform.position);
		laserShotLine.SetPosition(1, player.position);
		laserShotLine.enabled = true;
		laserShotLight.intensity = flashIntensity;
		AudioSource.PlayClipAtPoint(shotClip, laserShotLight.transform.position);
	}
}
