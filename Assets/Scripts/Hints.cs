using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class Hints : MonoBehaviour
{
    public Settings settings;

    public List<GameObject> spawned = new List<GameObject>();
    public GameObject arrows;
    public GameObject signal;
    public GameObject ampl;
    public GameObject freq;

    [SerializeField] private bool isLastLevel;
    [SerializeField] private bool isFirstLevel;

    private void Update()
    {
        if (settings.isLevelStart)
        {
            if (!isFirstLevel)
            {
                foreach (GameObject hint in GameObject.FindGameObjectsWithTag("Hint"))
                {
                        if (!spawned.Contains(hint))
                        {
                        spawned.Add(hint);
                        }
                    break;
                }
                arrows.SetActive(true);
            }
            else if (!spawned.Contains(signal))
            {
                signal.SetActive(true);
                spawned.Add(signal);
            }
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
