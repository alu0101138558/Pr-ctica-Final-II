using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastDoor : MonoBehaviour
{
    private GameObject thedoor;
	private AudioSource audioSource;
    public AudioClip abierta;
    public AudioClip cerrada;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter ( Collider obj  ){
		if (NumberOfTest.lavaLevelStatus() && NumberOfTest.forestLevelStatus()) {
			audioSource.PlayOneShot(abierta);
			thedoor = GameObject.FindWithTag("LastDoor");
			thedoor.GetComponent<Animation>().Play("open");
		}	
    }

    void OnTriggerExit ( Collider obj  ){
		if (NumberOfTest.lavaLevelStatus() && NumberOfTest.forestLevelStatus()) {
			audioSource.PlayOneShot(cerrada);
			thedoor = GameObject.FindWithTag("LastDoor");
			thedoor.GetComponent<Animation>().Play("close");
		}
    }
}
