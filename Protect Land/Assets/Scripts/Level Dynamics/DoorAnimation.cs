using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
	public bool requireKey;
	public AudioClip doorSwitchClip;
	public AudioClip accessDeniedClip;

	private Animator anim;
	private HashIDs hash;
	private GameObject player;
	private PlayerInventory playerInventory;
	private int count;

	void Awake()
	{
		anim = GetComponent<Animator>();
		hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();
		player = GameObject.FindGameObjectWithTag(Tags.player);
		playerInventory = player.GetComponent<PlayerInventory>();
	}

	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject == player)
		{
			if(requireKey)
			{
				if(playerInventory.hasKey)
				{
					count ++;
				}
				else{
					GetComponent<AudioSource>().clip = accessDeniedClip;
					GetComponent<AudioSource>().Play();
				}
			}
			else
			{
				count++;
			}
		}
		else if(other.gameObject.tag == Tags.enemy)
		{
			if(other is CapsuleCollider)
			{
				count++;
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject == player || other.gameObject.tag == Tags.enemy && other is SphereCollider)
		{
			count = Mathf.Max(0, count-1); //decreases count n returns 0 even if count = 1
		}
	}

	void Update()
	{
		anim.SetBool(hash.openBool, count > 0);
		if(anim.IsInTransition(0) && !GetComponent<AudioSource>().isPlaying)
		{
			GetComponent<AudioSource>().clip = doorSwitchClip;
			GetComponent<AudioSource>().Play();
		}
	}
}
