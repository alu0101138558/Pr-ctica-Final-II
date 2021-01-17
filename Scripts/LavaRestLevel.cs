using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaRestLevel : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip sound;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            audioSource.PlayOneShot(sound);
            StartCoroutine("Esperar");
        }
    }

    IEnumerator Esperar () {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("LavaWorld");
    }
}
