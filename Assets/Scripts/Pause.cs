using Unity.VisualScripting;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public Settings settings;
    public GameObject homeButton;
    public GameObject sinewaves;
    public GameObject arrows;
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
}
