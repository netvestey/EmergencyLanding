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
    private float maxAmpl = 2;
    private float minFreq = 0.5f;
    private float maxFreq = 15;

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

    public GameObject hintStart;
    public GameObject hintAmpl;
    public GameObject hintFreq;
    public GameObject hintSignal;
    public Button leftArrow;
    public Button rightArrow;
    public GameObject arrows;

    public GameObject victoryCanvas;
    public GameObject lastCanvas;
    [SerializeField] private bool isLastLevel;
    [SerializeField] private bool isFirstLevel;

    public HintsAppear hintsAppear;
    private bool signalAdded = false;

    public float totalSeconds;
    public float maxInt;
    public UnityEngine.Rendering.Universal.Light2D coolLight;

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
            hintsAppear.seenFreqTwice = true;
            hintsAppear.seenAmplTwice = true;
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
        for (int t = 0; t < Input.touchCount; t++)
        {
            Vector3 touchPosition = cam.ScreenToWorldPoint(Input.touches[t].position);
            UnityEngine.Touch touch = Input.GetTouch(t);
            Vector3 touchPos = cam.WorldToScreenPoint(touch.position);
            touchPos.z = 0f;


            if (touch.phase == TouchPhase.Began)
            {
                if (col == Physics2D.OverlapPoint(touchPos))
                {
                    screenPos = cam.WorldToScreenPoint(transform.position);
                    Vector3 vec3 = touchPos - screenPos;
                    angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;

                    waveSound.Play();
                }
            }

            if (touch.phase == TouchPhase.Moved)
            {
                if (col == Physics2D.OverlapPoint(touchPos))
                {
                    Vector3 vec3 = touchPos - screenPos;
                    float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
                    transform.eulerAngles = new Vector3(0, 0, angle + angleOffset);
                    progress = transform.eulerAngles.z / 360f * 2;
                    progress = Mathf.PingPong(progress, 1);


                    if (isAmpl == true)
                    {
                        sinewave.amplitude = Mathf.Lerp(minAmpl, maxAmpl, progress);
                        waveSound.pitch = Mathf.Lerp(maxPitch, minPitch, progress);

                        if (hintsAppear.seenAmpl == false)
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

                        if (hintsAppear.seenAmplTwice == false && hintsAppear.seenAmpl == true)
                        {
                            hintsAppear.seenAmplTwice = true;
                        }
                    }

                    else
                    {
                        sinewave.frequency = Mathf.Lerp(maxFreq, minFreq, progress);
                        waveSound.reverbZoneMix = Mathf.Lerp(maxRev, minRev, progress);

                        if (hintsAppear.seenFreq == false)
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

                        if (hintsAppear.seenFreqTwice == false && hintsAppear.seenFreq == true)
                        {
                            hintsAppear.seenFreqTwice = true;
                        }
                    }
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    waveSound.Stop();
                }
            }
        }

        if (sinewave.amplitude > (desiredAmpl - 0.2f) && sinewave.amplitude < (desiredAmpl + 0.2f) && sinewave.frequency > (desiredFreq - 2f) && sinewave.frequency < (desiredFreq + 2f))
        {
            if (!playedVictory)
            {
                playedVictory = true;
                victorySound.Play();
            }

            col = null;
            leftArrow.enabled = false;
            rightArrow.enabled = false;

            if (!isLastLevel)
            {
                victoryCanvas.SetActive(true);
            }
            else
            {
                lastCanvas.SetActive(true);
            }

        }

        if (hintsAppear.seenFreq == true && hintsAppear.seenAmpl == true && hintsAppear.seenSignal == false && hintsAppear.seenFreqTwice == true && hintsAppear.seenAmplTwice == true)
        {
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

        float howClose = ((sinewave.amplitude / desiredAmpl) + (sinewave.frequency / desiredFreq) / 2);
        coolLight.intensity = Mathf.Lerp(maxInt, 0, howClose);




        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (col == Physics2D.OverlapPoint(mousePos))
            {
                screenPos = cam.WorldToScreenPoint(transform.position);
                Vector3 vecm3 = Input.mousePosition - screenPos;
                angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(vecm3.y, vecm3.x)) * Mathf.Rad2Deg;

                waveSound.Play();
            }
        }

        if (Input.GetMouseButton(0))
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

                    if (hintsAppear.seenAmpl == false)
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

                    if (hintsAppear.seenAmplTwice == false && hintsAppear.seenAmpl == true)
                    {
                        hintsAppear.seenAmplTwice = true;
                    }
                }

                else
                {
                    sinewave.frequency = Mathf.Lerp(maxFreq, minFreq, progress);
                    waveSound.reverbZoneMix = Mathf.Lerp(maxRev, minRev, progress);

                    if (hintsAppear.seenFreq == false)
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

                    if (hintsAppear.seenFreqTwice == false && hintsAppear.seenFreq == true)
                    {
                        hintsAppear.seenFreqTwice = true;
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            waveSound.Stop();
        }

    }
    IEnumerator FlashLight()
    {
        float waitTime = totalSeconds / 2;

        while (coolLight.intensity < maxInt)
        {
            coolLight.intensity += Time.deltaTime / waitTime;
            yield return null;
        }
        while (coolLight.intensity > 0)
        {
            coolLight.intensity -= Time.deltaTime / waitTime;
            yield return null;
        }
        yield return null;
    }
}
