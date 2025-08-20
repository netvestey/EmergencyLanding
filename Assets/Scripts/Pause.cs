using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public Settings settings;
    public GameObject homeButton;
    public GameObject sinewaves;
    public GameObject arrows;
    public Button leftArrow;
    public Button rightArrow;
    public Button backToStart;
    public Hints hint;
    public void HideUI()
    {
        homeButton.SetActive(false);
        arrows.SetActive(false);
        sinewaves.SetActive(false);
        hint._text.text = "";
    }
    public void ShowUI()
    {
        homeButton.SetActive(true);
        sinewaves.SetActive(true);
        if (!settings.isFirstLevel)
            arrows.SetActive(true);
    }

    private void Update()
    {
        if (settings.isPaused)
        {
            backToStart.interactable = false;
            leftArrow.interactable = false;
            rightArrow.interactable = false;
        }   
        else
        {
            backToStart.interactable = true;
            leftArrow.interactable = true;
            rightArrow.interactable = true;
        }    
    }
}
