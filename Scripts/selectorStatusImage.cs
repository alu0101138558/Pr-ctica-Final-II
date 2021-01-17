using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectorStatusImage : MonoBehaviour
{
    private RawImage picture;
    public Texture[] status; 
    public string actualPicture;

    private void Start() {
        picture = GetComponent<RawImage>();
    }

    private void Update() {
        if (actualPicture == "GreenPortal") {
            if (NumberOfTest.forestLevelStatus()) {
                picture.texture = status[0];
            } else {
                picture.texture = status[1];
            }
        } else if (actualPicture == "RedPortal") {
            if (NumberOfTest.lavaLevelStatus()) {
                picture.texture = status[0];
            } else {
                picture.texture = status[1];
            }
        }
    }
}
