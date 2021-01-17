using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTP : MonoBehaviour
{
    public GameObject ObjectDes;
    private AudioSource audioSource;
    public AudioClip sound;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            audioSource.PlayOneShot(sound);
            other.transform.position = ObjectDes.transform.position;
        }
    }
}
