using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictorySound : MonoBehaviour
{
    public static VictorySound instance;

    private void Awake()
    {
        if (instance  == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
