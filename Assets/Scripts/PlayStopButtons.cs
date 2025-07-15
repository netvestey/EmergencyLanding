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

    public void Play()
    {
        SceneManager.LoadScene("PlayingLevel");
    }

    public void BackToStart()
    {
        SceneManager.LoadScene("StartScreen");
    }
        public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void HomeButtonActivate()
    {
        homeButtonCanvas.SetActive(true);
        Time.timeScale = 0;
        leftArrow.enabled = false;
        rightArrow.enabled = false;
    }
        public void HomeButtonDeactivate()
    {
        homeButtonCanvas.SetActive(false);
        Time.timeScale = 1;
        leftArrow.enabled = true;
        rightArrow.enabled = true;
    }

}
