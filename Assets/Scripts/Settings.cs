using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings: MonoBehaviour

{
    public HintsAppear hintsAppear;
    public bool isFirstLevel;
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
