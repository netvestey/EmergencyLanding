using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("PlayingLevel");
    }

    public void BackToStart()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
