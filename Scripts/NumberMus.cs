using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberMus : MonoBehaviour
{
    private GameObject[] mushList;
    private Text actualText;
    private int mushNumber;
    private static int actualMus;

    void Start()
    {
        mushList = GameObject.FindGameObjectsWithTag("Seta");
        mushNumber = mushList.Length;
        actualText = GetComponent<Text>();
    }


    void Update()
    {
        mushList = GameObject.FindGameObjectsWithTag("Seta");
        actualMus = mushList.Length;
        actualText.text = "x" + (mushNumber - actualMus);
    }

    public static int getActualMus () {
        return actualMus;
    }
}
