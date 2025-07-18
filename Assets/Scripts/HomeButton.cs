using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeButton : MonoBehaviour
{
    public Settings settings;
    public GameObject homeButton;
    public GameObject lamp;

    void Update()
    {
        if (settings.isLevelStart)
        {
            homeButton.SetActive(true);
            lamp.SetActive(true);
        }
        if (settings.isLevelWon)
        {
            homeButton.SetActive(false);
            lamp.SetActive(false);
        }
    }
}
