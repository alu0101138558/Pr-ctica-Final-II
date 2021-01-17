using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightDoor : MonoBehaviour
{
    private GameObject thedoor;
    private AudioSource audioSource;
    public AudioClip abierta;
    public AudioClip cerrada;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider obj)
    {
        if (!NumberOfTest.forestLevelStatus()) {
            audioSource.PlayOneShot(abierta);
            thedoor = GameObject.FindWithTag("RightDoor");
            thedoor.GetComponent<Animation>().Play("open");
        }
    }

    void OnTriggerExit(Collider obj)
    {
        if (!NumberOfTest.forestLevelStatus()) {
            audioSource.PlayOneShot(cerrada);
            thedoor = GameObject.FindWithTag("RightDoor");
            thedoor.GetComponent<Animation>().Play("close");
        }
    }
}
