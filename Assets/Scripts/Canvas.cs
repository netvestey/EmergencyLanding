using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Canvas : MonoBehaviour
{
    public Settings settings;

    [SerializeField] string startText;
    [SerializeField] string endText;
    private string fullText = "";

    public TextMeshProUGUI message;

    public GameObject fadeout;
    public GameObject button;

    public GameObject sounds;
    private List<AudioSource> dispatch = new List<AudioSource>();
    AudioSource randomd;

    private void Start()
    {
        AudioSource[] sound = sounds.GetComponents<AudioSource>();
        for (int i = 0; i < 4; i++)
        {

            dispatch.Add(sound[i]);
        }

        StartCoroutine(StartText());
    }

    public void ShowTextCanvas()
    {
        fadeout.SetActive(true);
        StartCoroutine(EndText());
    }

    public void TextCanvas()
    {      
        if (!settings.isLevelWon)
        {
            fadeout.SetActive(false);
            button.SetActive(false);
            settings.isPaused = false;
            settings.isLevelStart = true;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    IEnumerator StartText()
    {
        settings.isPaused = true;
        fadeout.SetActive(true);

        int rand = UnityEngine.Random.Range(0, dispatch.Count);
        randomd = dispatch[rand];
        randomd.Play();

        for (int i = 0; i < startText.Length; i++)
        {
            message.color = new Color(0.3921569f, 0.5058824f, 1, 1f);
            fullText = startText.Substring(0, i);
            message.text = fullText.Insert(i, "<color=#FFFFFF00>") + "</color>";
            yield return new WaitForSeconds(0.1f);
        }
        button.SetActive(true);
        randomd.Stop();
    }

    IEnumerator EndText()
    {
        settings.isPaused = true;
        fadeout.SetActive(true);

        int rand = UnityEngine.Random.Range(0, dispatch.Count);
        randomd = dispatch[rand];
        randomd.Play();

        for (int i = 0; i < endText.Length; i++)
        {
            message.color = new Color(0.7921569f, 0.572549f, 0.003921569f, 1f);
            fullText = endText.Substring(0, i);
            message.text = fullText.Insert(i, "<color=#FFFFFF00>") + "</color>";
            yield return new WaitForSeconds(0.1f);
        }
        button.SetActive(true);
        randomd.Stop();

    }
}
