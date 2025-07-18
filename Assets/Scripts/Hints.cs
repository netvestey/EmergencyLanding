using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;
using TMPro;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Hints : MonoBehaviour
{
    public Settings settings;

    public List<GameObject> spawned = new List<GameObject>();
    public GameObject arrows;
    public GameObject ampl;
    public GameObject freq;

    private void Update()
    {      
        if (settings.isLevelStart && !settings.isFirstLevel)
        {
            arrows.SetActive(true);
        }
        
        
        if (settings.isLevelWon)
        {
            for (int i = 0; i < spawned.Count; i++)
            {
                if (spawned[i].activeInHierarchy)
                {
                    spawned[i].SetActive(false);
                }
            }

            arrows.SetActive(false);
        }
    }

    public void SwitchLeft()
    {   
        if (!settings.isPaused)
        {
             for (int i = 0; i < spawned.Count; i++)
            {
                if (spawned[i].activeInHierarchy)
                {
                    spawned[i].SetActive(false);
                    if (spawned[i] != spawned[0])
                    {
                       spawned[i - 1].SetActive(true);
                    }
                    else
                    {
                        spawned[spawned.Count - 1].SetActive(true);
                    }
                    break;
                }
            }
        }   
    }

    public void SwitchRight()
    {
        if (!settings.isPaused)
        {
            for (int i = 0; i < spawned.Count; i++)
            {
                if (spawned[i].activeInHierarchy)
                {
                    spawned[i].SetActive(false);
                    if (spawned[i] != spawned[spawned.Count - 1])
                    {
                        spawned[i + 1].SetActive(true);
                    }
                    else
                    {
                        spawned[0].SetActive(true);
                    }
                    break;
                }
            }
        }
    }
}
