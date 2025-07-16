using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public GameObject homeButtonCanvas;
    public HintsAppear hintsAppear;
    public GameObject buttonS;
    private AudioSource buttonSound;

    private void Start()
    {
        buttonSound = buttonS.GetComponent<AudioSource>();
    }

    public void Play()
    {
        buttonSound.Play();
        SceneManager.LoadScene("PlayingLevel");
    }

    public void BackToStart()
    {
        buttonSound.Play();
        SceneManager.LoadScene("StartScreen");
    }
        public void NextLevel()
    {
        buttonSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void HomeButtonActivate()
    {
        buttonSound.Play();
        homeButtonCanvas.SetActive(true);
        hintsAppear.isPaused = true;
    }
        public void HomeButtonDeactivate()
    {
        buttonSound.Play();
        homeButtonCanvas.SetActive(false);
        hintsAppear.isPaused = false;
    }

}
