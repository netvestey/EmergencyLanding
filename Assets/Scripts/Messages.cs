using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class Messages : MonoBehaviour
{
    public Settings settings;
    public Pause pause;
    public Buttons trans;

    private string startText;
    private string endText;
    private string dutyText;
    private string fullText = "";

    public TextMeshProUGUI message;
    private bool isRichText = false;

    public GameObject fadeout;
    private Button button; 
    
    public MessagesSounds mSounds;
    AudioSource randomm;

    private void Start()
    {
        button = fadeout.GetComponent<Button>();
        
        if (settings.isFirstLevel)
        {
            startText = "Центр управления полётами, город Королёв. Три раза прими сигнал <br>от космонавтов во время спуска <br>на Землю.<br>—>";
            endText = "«Приём. «Союз» выходит на снижение. <br>Все системы работают в штатном режиме, экипаж чувствует себя хорошо».<br>—>";
        }
        else if (!settings.isLastLevel)
        {
            startText = "Прими второй сигнал — подтверди состояние спускаемого аппарата.<br>—>";
            endText = "«Приём. Основной парашют раскрыт. Спуск стабильный. Готовимся к посадке».<br>—>";
        }
        else
        {
            startText = "Прими третий сигнал — подтверди координаты приземления.<br>—>";
            endText = "«Приём. Сильный ветер. Направляем координаты скорректированного приземления».<br>—>";
        }
        
        dutyText = "«Благодарю за службу!»<br>—>";

        StartCoroutine(TypeText(startText, new Color(0.3921569f, 0.5058824f, 1, 1f)));
    }

    public void ShowMessage()
    {
        fadeout.SetActive(true);
        button.interactable = false;
        pause.HideUI(); 
        StartCoroutine(TypeText(endText, new Color(0.7921569f, 0.572549f, 0.003921569f, 1f)));
    }

    public void HideMessage()
    {
        if (settings.isLevelStart)
        {
            fadeout.SetActive(false);
            settings.isPaused = false;
            pause.ShowUI();
            settings.isUIVisible = true; 
            settings.isLevelStart = false;
        }
        else if (!settings.isLevelStart && settings.isGameWon)
        {
            button.interactable = false;
            StartCoroutine(TypeText(dutyText, new Color(0.3921569f, 0.5058824f, 1, 1f)));
        }
        else
        {
            trans.NextLevel();
        }
    }

    IEnumerator TypeText(string textType, Color color)
    {
        fullText = "";

        PlayMessageS(); 

        message.color = color;

        foreach (char i in textType.ToCharArray())
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
        button.interactable = true; 
        randomm.Stop();
    }

    void PlayMessageS()
    {
        int rand = Random.Range(0, mSounds.randmsound.Length);
        randomm = mSounds.randmsound[rand];
        randomm.Play();
    }
}
