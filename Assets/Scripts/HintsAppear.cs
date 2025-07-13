using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HintsAppear : MonoBehaviour
{
    public bool seenAmpl;
    public bool seenFreq;
    public bool seenSignal;

    public List<GameObject> hintsSpawned = new List<GameObject>();
    public GameObject hintStart;

    private void Start()
    {
        hintsSpawned.Add(hintStart);
    }

    public void SwitchLeft()
    {
        for (int i = 0; i < hintsSpawned.Count; i++)
        {
            if (hintsSpawned[i].activeInHierarchy)
            {                
                hintsSpawned[i].SetActive(false);
                if (hintsSpawned[i] != hintsSpawned[0])
                {
                    hintsSpawned[i - 1].SetActive(true);
                }
                else
                {
                    hintsSpawned[hintsSpawned.Count - 1].SetActive(true);
                }
                break;
            }
        }
    }

    public void SwitchRight()
    {
        for (int i = 0; i < hintsSpawned.Count; i++)
        {
            if (hintsSpawned[i].activeInHierarchy)
            {
                hintsSpawned[i].SetActive(false);
                if (hintsSpawned[i] != hintsSpawned[hintsSpawned.Count - 1])
                {
                    hintsSpawned[i + 1].SetActive(true);
                }
                else
                {
                    hintsSpawned[0].SetActive(true);
                }
                break;
            }
        }
    }
}
