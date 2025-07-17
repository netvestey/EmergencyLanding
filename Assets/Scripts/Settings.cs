using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Settings: MonoBehaviour

{
    public bool isPaused;
    public bool isLevelWon;
    public bool isLevelStart;
    public bool isFirstLevel;
    public GameObject[] loadAtStart;
      
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
