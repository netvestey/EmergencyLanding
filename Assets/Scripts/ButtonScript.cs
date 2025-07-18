using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Settings settings;
    [SerializeField] private Image image;

    public GameObject buttonSound;
    private AudioSource button;

    private void Start()
    {
        button = buttonSound.GetComponent<AudioSource>();

        Color color = image.color;
        color.a = 1;
        image.color = color;
        StartCoroutine(ChangeAlpha(0.2f, 0, null));
    }

    public void Sound()
    {
        button.Play();
    }

    public void Play()
    {
        void Finished()
        {
            SceneManager.LoadScene("PlayingLevel");
        }

        StartCoroutine(ChangeAlpha(0.2f, 1, Finished));
    }

    public void Exit()
    {
        void Finished()
        {
            SceneManager.LoadScene("StartScreen");
        }

        StartCoroutine(ChangeAlpha(0.2f, 1, Finished));
    }

    public void NextLevel()
    {
        void Finished()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        StartCoroutine(ChangeAlpha(0.2f, 1, Finished));
    }

    public void GoToTitles()
    {
        void Finished()
        {
            settings.isPaused = false;
            SceneManager.LoadScene("Titles");
        }

        StartCoroutine(ChangeAlpha(0.2f, 1, Finished));
    }

    public void GoToDevs()
    {
        void Finished()
        {
            settings.isPaused = false;
            SceneManager.LoadScene("Devs");
        }

        StartCoroutine(ChangeAlpha(0.2f, 1, Finished));
    }

    IEnumerator ChangeAlpha(float duration, float target, Action finished)
    {
        float time = 0;
        float sourceAlpha = image.color.a;

        Color color;

        while (time < duration)
        {
            yield return null;
            time += Time.deltaTime;

            float phase = time / duration;

            color = image.color;
            color.a = Mathf.Lerp(sourceAlpha, target, phase);
            image.color = color;
        }

        color = image.color;
        color.a = target;
        image.color = color;

        finished?.Invoke();
    }
}
