using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings: MonoBehaviour

{
    public bool isPaused;
    public bool isLevelWon;
    public bool isGameWon;
    public bool isLevelStart;
    public bool isFirstLevel;
    public bool isLastLevel;
    public bool isVideoPlaying;
    void Start()
    {
        Screen.SetResolution(3840, 2160, true);        
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
