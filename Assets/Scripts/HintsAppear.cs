using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HintsAppear : MonoBehaviour
{
    public bool seenAmpl;
    public bool seenAmplTwice;
    public bool seenFreq;
    public bool seenFreqTwice;
    public bool seenSignal;

    public List<GameObject> hintsSpawned = new List<GameObject>();
    public GameObject hintStart;

    public GameObject buttonS;
    private AudioSource buttonSound;

    private void Start()
    {
        hintsSpawned.Add(hintStart);
        buttonSound = buttonS.GetComponent<AudioSource>();
    }

    public void SwitchLeft()
    {
        buttonSound.Play();

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
        buttonSound.Play();

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
