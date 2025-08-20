using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public Settings settings;
    public Pause pause;
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

    public void Exit()
    {
        static void Finished()
        {
            SceneManager.LoadScene("StartScreen");
        }

        StartCoroutine(ChangeAlpha(0.2f, 1, Finished));
    }

    public void NextLevel()
    {
        static void Finished()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        StartCoroutine(ChangeAlpha(0.2f, 1, Finished));
    }

    public void GoToTitles()
    {
        static void Finished()
        {
            SceneManager.LoadScene("Titles");
        }

        StartCoroutine(ChangeAlpha(0.2f, 1, Finished));
    }

    public void GoToDevs()
    {
        static void Finished()
        {
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
