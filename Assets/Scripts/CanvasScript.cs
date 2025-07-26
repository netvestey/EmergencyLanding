using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
    public Settings settings;
    public ButtonScript trans;

    private string startText;
    private string endText;
    [SerializeField] string dutyText;
    private string fullText = "";

    public TextMeshProUGUI message;
    private bool isRichText = false;

    public GameObject fadeout;
    public GameObject button;

    public Hints hint;

    public GameObject sounds;
    private List<AudioSource> dispatch = new List<AudioSource>();
    AudioSource randomd;

    private bool reachedVictory = false;

    private void Start()
    {
        AudioSource[] sound = sounds.GetComponents<AudioSource>();
        for (int i = 1; i < 4; i++)
        {

            dispatch.Add(sound[i]);
        }

        if (settings.isFirstLevel)
        {
            startText = "����� ���������� �������, ����� ������. ��� ���� ����� ������ �� ����������� <br>�� ����� ������ �� �����.<br>�>";
            endText = "�����. ����� ������� �� ��������. <br>��� ������� �������� � ������� ������, ������ ��������� ���� ������.<br>�>";
        }
        else if (!settings.isLastLevel && !settings.isFirstLevel)
        {
            startText = "����� ������ ������ � ��������� ��������� ����������� ��������.<br>�>";
            endText = "�����. �������� ������� �������. ����� ����������. ��������� � �������.<br>�>";
        }
        else
        {
            startText = "����� ������ ������ � ��������� ���������� �����������.<br>�>";
            endText = "�����. ������� �����. ���������� ���������� ������������������ ������������.<br>�>";
        }
        
       dutyText = "���������� �� ������!�<br>�>";

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
            hint.spawned[0].SetActive(true);
        }
        else if (settings.isLevelWon && settings.isLastLevel && !settings.isGameWon && !reachedVictory)
        {
            StartCoroutine(VictoryText());
            reachedVictory = true;
        }
        else
        {
            trans.NextLevel();
        }
    }

    IEnumerator StartText()
    {
        settings.isPaused = true;
        fadeout.SetActive(true);
        fullText = "";

        int rand = UnityEngine.Random.Range(0, dispatch.Count);
        randomd = dispatch[rand];
        randomd.Play();

        message.color = new Color(0.3921569f, 0.5058824f, 1, 1f);

        foreach (char i in startText.ToCharArray())
        {
            if (i == '<' || isRichText)
            {
                isRichText = true;
                fullText += i;
                message.text = fullText;
                if (i == '>')
                {
                    isRichText = false;
                }
            }
            else
            {
                fullText += i;
                message.text = fullText;
                yield return new WaitForSeconds(0.1f);
            }
        }
        button.SetActive(true);
        randomd.Stop();
    }

    IEnumerator EndText()
    {
        settings.isPaused = true;
        fadeout.SetActive(true);
        fullText = "";

        int rand = UnityEngine.Random.Range(0, dispatch.Count);
        randomd = dispatch[rand];
        randomd.Play();

        message.color = new Color(0.7921569f, 0.572549f, 0.003921569f, 1f);

        foreach (char i in endText.ToCharArray())
        {
            if (i == '<' || isRichText)
            {
                isRichText = true;
                fullText += i;
                message.text = fullText;
                if (i == '>')
                {
                    isRichText = false;
                }
            }
            else
            {
                fullText += i;
                message.text = fullText;
                yield return new WaitForSeconds(0.1f);
            }
        }
        button.SetActive(true);
        randomd.Stop();

    }

    IEnumerator VictoryText()
    {
        fullText = "";
        button.SetActive(false);
        randomd.Play();
        message.color = new Color(0.3921569f, 0.5058824f, 1, 1f);
        foreach (char i in dutyText.ToCharArray())
        {
            if (i == '<' || isRichText)
            {
                isRichText = true;
                fullText += i;
                message.text = fullText;
                if (i == '>')
                {
                    isRichText = false;
                }
            }
            else
            {
                fullText += i;
                message.text = fullText;
                yield return new WaitForSeconds(0.1f);
            }
        }

        button.SetActive(true);
        randomd.Stop();
    }
}
