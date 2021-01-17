using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeSampleSaver
{
    private static TimeSampleSaver instance = null;
    public static TimeSampleSaver Instance
    {
        get
        {
            if (instance == null)
                instance = new TimeSampleSaver();
            return instance;
        }
    }

    private int timeSampleSaved = 0;
    public int TimeSampleSaved { get => timeSampleSaved; set => timeSampleSaved = value; }

    private float timeSaved = 0;
    public float TimeSaved { get => timeSaved; set => timeSaved = value; }
    TimeSampleSaver() { }

}
public class MainThemeController : MonoBehaviour
{
    public AudioSource mainTheme;
    // Start is called before the first frame update
    void Start()
    {
        this.mainTheme.timeSamples = TimeSampleSaver.Instance.TimeSampleSaved;
    }
    // Update is called once per frame
    void Update()
    {
        TimeSampleSaver.Instance.TimeSampleSaved = this.mainTheme.timeSamples;
    }
}
