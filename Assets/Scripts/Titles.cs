using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titles : MonoBehaviour
{
    public Settings settings;

    public GameObject clockText;
    public GameObject towerText;
    public GameObject buttonText;
    public GameObject headphonesText;

    public List<GameObject> titlesText = new List<GameObject>();

    private void Start()
    {
        //foreach (GameObject titlesT in GameObject.FindGameObjectsWithTag("TitlesText"))
        //{

            //titlesText.Add(titlesT);
            //titlesT.SetActive(false);
        //}

    }

    public void GoToClockText()
    {
        for (int i = 0; i < titlesText.Count; i++)
        {
            if (titlesText[i].activeInHierarchy)
            {
                titlesText[i].SetActive(false);
            }            
        }
        titlesText[0].SetActive(true);
    }

    public void GoToTowerText()
    {
        for (int i = 0; i < titlesText.Count; i++)
        {
            if (titlesText[i].activeInHierarchy)
            {
                titlesText[i].SetActive(false);
            }
        }
        titlesText[1].SetActive(true);
    }

    public void GoToButtonText()
    {
        for (int i = 0; i < titlesText.Count; i++)
        {
            if (titlesText[i].activeInHierarchy)
            {
                titlesText[i].SetActive(false);
            }
        }
        titlesText[2].SetActive(true);
    }

    public void GoToHeadphonesText()
    {
        for (int i = 0; i < titlesText.Count; i++)
        {
            if (titlesText[i].activeInHierarchy)
            {
                titlesText[i].SetActive(false);
            }
        }
        titlesText[3].SetActive(true);
    }
}
