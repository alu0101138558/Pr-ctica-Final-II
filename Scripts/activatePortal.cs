using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activatePortal : MonoBehaviour
{

    public GameObject portal;
    private bool firstTry;

    void Start()
    {
        portal.gameObject.SetActive(false);
        firstTry = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (NumberMus.getActualMus() == 0 && !firstTry) {
            portal.gameObject.SetActive(true);
        } else {
            firstTry = false;
        }
    }
}
