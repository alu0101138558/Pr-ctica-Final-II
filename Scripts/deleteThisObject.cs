using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteThisObject : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip sound;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void delteThis () {
        audioSource.PlayOneShot(sound);
        StartCoroutine("Esperar");
    }
    
    IEnumerator Esperar() {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
