using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeButton : MonoBehaviour
{
    public Settings settings;
    public GameObject homeButton;

    void Update()
    {
        if (settings.isLevelStart)
        {
            homeButton.SetActive(true);
        }
        if (settings.isLevelWon)
        {
            homeButton.SetActive(false);
        }
    }
}
