using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotateRotators : MonoBehaviour
{
    private Camera cam;
    private Vector3 screenPos;
    private float angleOffset;
    private Collider2D col;
    private float currentAngle;
    private float newAngle;
    private float isClockwise;

    public Sinewave sinewave;
    public Sinewave desiredsine;

    private float minAmpl = 0.3f;
    private float maxAmpl = 3f;
    private float minFreq = 2f;
    private float maxFreq = 25f;
    private float waveChange;
    private float newWave;
    public bool isAmpl;

    private void Start()
    {
        cam = Camera.main;
        col = GetComponent<Collider2D>();
    }

    private void Update()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            if (col == Physics2D.OverlapPoint(mousePos))
            {
                currentAngle = transform.eulerAngles.z;

                screenPos = cam.WorldToScreenPoint(transform.position);
                Vector3 vec3 = Input.mousePosition - screenPos;
                angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;
            }
        }
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2))
        {
            if (col == Physics2D.OverlapPoint(mousePos))
            {
                Vector3 vec3 = Input.mousePosition - screenPos;
                float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, 0, angle + angleOffset);
                
                newAngle = transform.eulerAngles.z;
                float angleDif = newAngle - currentAngle; 
                if (angleDif < 0)
                {
                    angleDif += 360;
                }
                if(angleDif > 0 && angleDif < 180)
                {
                    isClockwise = -1;
                }
                else
                {
                    isClockwise = 1;
                }

                waveChange = Mathf.Abs(transform.rotation.z) * 0.01f * isClockwise;
                if (isAmpl == true)
                {
                    newWave = sinewave.amplitude + waveChange;

                    if (newWave > minAmpl && newWave < maxAmpl)
                    {

                        sinewave.amplitude += waveChange;

                        if (desiredsine.amplitude == sinewave.amplitude && desiredsine.frequency == sinewave.frequency)
                        {
                            SceneManager.LoadScene("VictoryScreen");
                        }
                    }   
                }
                else
                {
                    newWave = sinewave.frequency + waveChange;

                    if (newWave > minFreq && newWave < maxFreq)
                    {

                        sinewave.frequency += waveChange;

                        if (desiredsine.amplitude == sinewave.amplitude && desiredsine.frequency == sinewave.frequency)
                        {
                            SceneManager.LoadScene("VictoryScreen");
                        }
                    }
                }
            }
        }

    }
}
