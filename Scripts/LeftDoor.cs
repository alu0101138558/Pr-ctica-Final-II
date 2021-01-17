using UnityEngine;
using System.Collections;

public class LeftDoor: MonoBehaviour {

	private GameObject thedoor;
	private AudioSource audioSource;
    public AudioClip abierta;
    public AudioClip cerrada;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter ( Collider obj  ){
		if (!NumberOfTest.lavaLevelStatus()) {
			audioSource.PlayOneShot(abierta);
			thedoor = GameObject.FindWithTag("LeftDoor");
			thedoor.GetComponent<Animation>().Play("open");
		}	
    }

    void OnTriggerExit ( Collider obj  ){
		if (!NumberOfTest.lavaLevelStatus()) {
			audioSource.PlayOneShot(cerrada);
			thedoor = GameObject.FindWithTag("LeftDoor");
			thedoor.GetComponent<Animation>().Play("close");
		}
    }
}