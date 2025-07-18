using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.UI;

public class LampLight : MonoBehaviour
{
    public GameObject lamp;
    private SpriteRenderer sprite;
    private float opacity;

    private float cur;
    private float percent;
    private int intpercent;
    public Sinewave sinewave;
    public Sinewave desiredsine;

    private float amplIndex;
    private float freqIndex;
    void Start()
    {
        sprite = lamp.GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        amplIndex = Mathf.Max(sinewave.amplitude, desiredsine.amplitude) / Mathf.Min(sinewave.amplitude, desiredsine.amplitude);
        freqIndex = Mathf.Max(sinewave.frequency, desiredsine.frequency) / Mathf.Min(sinewave.frequency, desiredsine.frequency);
        cur = (amplIndex + freqIndex) / 2;
        percent = 1 / cur * 100f;
        intpercent = Convert.ToInt32(percent);

        opacity = Mathf.Lerp(100, 0, percent);
        sprite.color = new Color(1f, 1f, 1f, opacity);
    }
}
