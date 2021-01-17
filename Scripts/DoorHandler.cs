using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
	public GameObject thedoor;
	private AudioSource audioSource;
	public AudioClip abierta;
	public AudioClip cerrada;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider obj)
	{
		audioSource.PlayOneShot(abierta);
		thedoor.GetComponent<Animation>().Play("open");

	}

	void OnTriggerExit(Collider obj)
	{

		audioSource.PlayOneShot(cerrada);
		thedoor.GetComponent<Animation>().Play("close");
	}
}
