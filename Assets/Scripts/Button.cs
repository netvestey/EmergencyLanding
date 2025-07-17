using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public Settings settings;

    public GameObject buttonSound;
    private AudioSource button;

    private void Start()
    {
        button = buttonSound.GetComponent<AudioSource>();
    }

    public void Sound()
    {
        button.Play();
    }

    public void Play()
    {
        SceneManager.LoadScene("PlayingLevel");
    }

    public void Exit()
    {
         SceneManager.LoadScene("StartScreen");
    }

    public void GoToTitles()
    {
       settings.isPaused = false;
       SceneManager.LoadScene("Titles");
    }

    public void GoToDevs()
    {
        settings.isPaused = false;
        SceneManager.LoadScene("Devs");
    } 
}
