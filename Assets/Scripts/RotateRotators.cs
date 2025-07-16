using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using UnityEngine.InputSystem.EnhancedTouch;

public class RotateRotators : MonoBehaviour
{
    private Camera cam;
    private Vector3 screenPos;
    private float angleOffset;
    private Collider2D col;

    public Sinewave sinewave;
    public Sinewave desiredsine;
    private float desiredAmpl;
    private float desiredFreq;

    private float minAmpl = 0.1f;
    private float maxAmpl = 1;
    private float minFreq = 0.5f;
    private float maxFreq = 10;

    private float minPitch;
    private float maxPitch;
    private float minRev;
    private float maxRev;

    [SerializeField] bool isAmpl;
    private float progress;

    public GameObject sounds;
    private AudioSource victorySound;
    private AudioSource waveSound;
    private bool playedVictory;

    public GameObject hintAmpl;
    public GameObject hintFreq;
    public GameObject hintSignal;
    public GameObject arrows;

    public GameObject victoryCanvas;
    public GameObject lastCanvas;
    [SerializeField] private bool isLastLevel;
    [SerializeField] private bool isFirstLevel;

    public HintsAppear hintsAppear;
    private bool signalAdded = false;

    //public float totalSeconds;
    //public float maxInt;
    //public UnityEngine.Rendering.Universal.Light2D coolLight;

    private void Start()
    {
        cam = Camera.main;
        col = GetComponent<Collider2D>();
        desiredAmpl = desiredsine.amplitude;
        desiredFreq = desiredsine.frequency;

        AudioSource[] allAudioSources = sounds.GetComponents<AudioSource>();
        victorySound = allAudioSources[0];
        waveSound = allAudioSources[1];
        minPitch = waveSound.pitch * 0.5f;
        maxPitch = waveSound.pitch * 2f;
        minRev = waveSound.reverbZoneMix * 0.5f;
        maxRev = waveSound.reverbZoneMix * 2f;

        if (!isFirstLevel)
        {
            hintsAppear.seenFreq = true;
            hintsAppear.seenSignal = true;
            arrows.SetActive(true);
            hintsAppear.hintsSpawned.Add(hintAmpl);
            hintsAppear.hintsSpawned.Add(hintFreq);
            hintsAppear.hintsSpawned.Add(hintSignal);
        }

        //StartCoroutine(FlashLight());
    }

    private void Update()
    {
        //for (int t = 0; t < Input.touchCount; t++)
        {
            //Vector3 touchPosition = cam.ScreenToWorldPoint(Input.touches[t].position);
            //UnityEngine.Touch touch = Input.GetTouch(t);
            //Vector3 touchPos = cam.WorldToScreenPoint(touch.position);
            //touchPos.z = 0f;
        }
         
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && !hintsAppear.isPaused)
        {
            if (col == Physics2D.OverlapPoint(mousePos))
            {
                screenPos = cam.WorldToScreenPoint(transform.position);
                Vector3 vecm3 = Input.mousePosition - screenPos;
                angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(vecm3.y, vecm3.x)) * Mathf.Rad2Deg;

                waveSound.Play();
            }
        }

        if (Input.GetMouseButton(0) && !hintsAppear.isPaused)
        {
            if (col == Physics2D.OverlapPoint(mousePos))
            {
                Vector3 vecm3 = Input.mousePosition - screenPos;
                float anglem = Mathf.Atan2(vecm3.y, vecm3.x) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, 0, anglem + angleOffset);
                progress = transform.eulerAngles.z / 360f * 2;
                progress = Mathf.PingPong(progress, 1);


                if (isAmpl == true)
                {
                    sinewave.amplitude = Mathf.Lerp(minAmpl, maxAmpl, progress);
                    waveSound.pitch = Mathf.Lerp(maxPitch, minPitch, progress);

                    if (hintsAppear.seenAmpl == false && hintsAppear.isPaused == false)
                    {
                        for (int i = 0; i < hintsAppear.hintsSpawned.Count; i++)
                        {
                            if (hintsAppear.hintsSpawned[i].activeInHierarchy)
                            {
                                hintsAppear.hintsSpawned[i].SetActive(false);
                                break;
                            }
                        }
                        hintAmpl.SetActive(true);
                        arrows.SetActive(true);
                        hintsAppear.seenAmpl = true;
                        hintsAppear.hintsSpawned.Add(hintAmpl);


                    }
                }

                else
                {
                    sinewave.frequency = Mathf.Lerp(maxFreq, minFreq, progress);
                    waveSound.reverbZoneMix = Mathf.Lerp(maxRev, minRev, progress);

                    if (hintsAppear.seenFreq == false && hintsAppear.isPaused == false)
                    {
                        for (int i = 0; i < hintsAppear.hintsSpawned.Count; i++)
                        {
                            if (hintsAppear.hintsSpawned[i].activeInHierarchy)
                            {
                                hintsAppear.hintsSpawned[i].SetActive(false);
                                break;
                            }
                        }
                        hintFreq.SetActive(true);
                        arrows.SetActive(true);
                        hintsAppear.seenFreq = true;
                        hintsAppear.hintsSpawned.Add(hintFreq);
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && !hintsAppear.isPaused)
        {
            waveSound.Stop();
        }


        if (sinewave.amplitude > (desiredAmpl - 0.1f) && sinewave.amplitude < (desiredAmpl + 0.1f) && sinewave.frequency > (desiredFreq - 1f) && sinewave.frequency < (desiredFreq + 1f))
        {
            StartCoroutine(HasWon());
        }

        if (hintsAppear.seenFreq == true && hintsAppear.seenAmpl == true && hintsAppear.seenSignal == false && hintsAppear.isPaused == false)
        {
            StartCoroutine(Signal());
        }

        //float howClose = ((sinewave.amplitude / desiredAmpl) + (sinewave.frequency / desiredFreq) / 2);
        //coolLight.intensity = Mathf.Lerp(maxInt, 0, howClose);

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

    IEnumerator Signal()
    {
        yield return new WaitForSeconds(7);
        for (int i = 0; i < hintsAppear.hintsSpawned.Count; i++)
        {
            if (hintsAppear.hintsSpawned[i].activeInHierarchy)
            {
                hintsAppear.hintsSpawned[i].SetActive(false);
                break;
            }
        }
        hintSignal.SetActive(true);
        hintsAppear.seenSignal = true;

        if (signalAdded == false)
        {
            hintsAppear.hintsSpawned.Add(hintSignal);
            signalAdded = true;
        }
    }
    IEnumerator HasWon()
    {
        if (!playedVictory)
        {
            playedVictory = true;
            victorySound.Play();
        }

        hintsAppear.isPaused = true;

        sinewave.frequency = Mathf.Lerp(sinewave.frequency, desiredFreq, 1);
        sinewave.amplitude = Mathf.Lerp(sinewave.amplitude, desiredAmpl, 1);

        yield return new WaitForSeconds(1);

        if (!isLastLevel)
        {
            victoryCanvas.SetActive(true);
        }
        else
        {
            lastCanvas.SetActive(true);
        }
    }
}
