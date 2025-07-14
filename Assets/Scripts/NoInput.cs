using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoInput : MonoBehaviour
{
    private float inputTimer;

    void Start()
    {
        inputTimer = 0;
    }

    void Update()
    {
        inputTimer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            inputTimer = 0;
        }

        if (inputTimer >= 60f)
        {
            inputTimer = 0;
            SceneManager.LoadScene("StartScreen");
        }
    }
}
