using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public GameObject homeButtonCanvas;
    public Button leftArrow;
    public Button rightArrow;
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
        Time.timeScale = 0;
        leftArrow.enabled = false;
        rightArrow.enabled = false;
    }
        public void HomeButtonDeactivate()
    {
        buttonSound.Play();
        homeButtonCanvas.SetActive(false);
        Time.timeScale = 1;
        leftArrow.enabled = true;
        rightArrow.enabled = true;
    }

}
