using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ProgressCounter : MonoBehaviour
{
    public TextMeshProUGUI percentText;
    private float cur;
    private float percent;
    private int intpercent;
    public Sinewave sinewave;
    public Sinewave desiredsine;

    private float amplIndex;
    private float freqIndex;

    public float totalSeconds;
    public float maxInt;
    public UnityEngine.Rendering.Universal.Light2D coolLight;

    void Update()
    {
        amplIndex = Mathf.Max(sinewave.amplitude, desiredsine.amplitude) / Mathf.Min(sinewave.amplitude, desiredsine.amplitude);
        freqIndex = Mathf.Max(sinewave.frequency, desiredsine.frequency) / Mathf.Min(sinewave.frequency, desiredsine.frequency);
        cur = (amplIndex + freqIndex) / 2;        
        percent = 1 / cur * 100f;
        intpercent = Convert.ToInt32(percent);
        percentText.text = intpercent.ToString() + " %";

        coolLight.intensity = Mathf.Lerp(maxInt, 0, percent);

    }

    //IEnumerator FlashLight()
    //{
    //float waitTime = totalSeconds / 2;

    //while (coolLight.intensity < maxInt)
    //{
    //coolLight.intensity += Time.deltaTime / waitTime;
    //yield return null;
    //}
    //while (coolLight.intensity > 0)
    //{
    //coolLight.intensity -= Time.deltaTime / waitTime;
    //yield return null;
    // }
    //yield return null;
    //}
}
