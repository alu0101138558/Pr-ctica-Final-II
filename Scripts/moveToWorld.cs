using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveToWorld : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip sound;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }
    
    void OnTriggerEnter(Collider obj)
    {
        if (this.tag == "RedPortal" && obj.tag == "Player") {
            audioSource.PlayOneShot(sound);
            StartCoroutine("Esperar", "LavaWorld");
        } else if (this.tag == "GreenPortal" && obj.tag == "Player") {
            audioSource.PlayOneShot(sound);
            StartCoroutine("Esperar", "BrightDay");
        } else if (this.tag == "Inicio" && obj.tag == "Player") {
            audioSource.PlayOneShot(sound);
            StartCoroutine("Esperar", "LobbyGame");
        } else if (this.tag == "FinForest" && obj.tag == "Player") {
            NumberOfTest.forestComplete();
            audioSource.PlayOneShot(sound);
            StartCoroutine("Esperar", "LobbyGame");
        } else if (this.tag == "FinLava" && obj.tag == "Player") {
            NumberOfTest.lavaComplete();
            audioSource.PlayOneShot(sound);
            StartCoroutine("Esperar", "LobbyGame");
        } else if (this.tag == "EndPortal" && obj.tag == "Player") {
            NumberOfTest.reset();
            audioSource.PlayOneShot(sound);
            StartCoroutine("Esperar", "MainMenu");
        }
    }

    IEnumerator Esperar (string name) {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(name);
    }
}
