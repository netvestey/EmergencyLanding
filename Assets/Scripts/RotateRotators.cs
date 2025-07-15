using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.UI;

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

    private float minAmpl;
    private float maxAmpl;
    private float minFreq;
    private float maxFreq;

    private float minPitch;
    private float maxPitch;
    private float minRev;
    private float maxRev;

    [SerializeField] bool isAmpl;
    private float progress;

    private AudioSource waveSound;
    public GameObject soundVictory;
    private AudioSource victorySound;
    public GameObject soundHints;
    private AudioSource hintsSound; 

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
        minAmpl = 0.1f;
        maxAmpl = 2;
        minFreq = 0.5f;
        maxFreq = 15;

        waveSound = sinewave.GetComponent<AudioSource>();
        victorySound = soundVictory.GetComponent<AudioSource>();
        hintsSound = soundHints.GetComponent<AudioSource>();
        minPitch = waveSound.pitch * 0.5f;
        maxPitch = waveSound.pitch * 2f;
        minRev = waveSound.reverbZoneMix * 0.5f;
        maxRev = waveSound.reverbZoneMix * 2f;

        hintStart.SetActive(true);
        hintsSound.Play();

        if (!isFirstLevel)
        {
            hintsAppear.seenFreq = true;
            hintsAppear.seenAmpl = true;
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
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (col == Physics2D.OverlapPoint(mousePos))
            {
                screenPos = cam.WorldToScreenPoint(transform.position);
                Vector3 vec3 = Input.mousePosition - screenPos;
                angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;

                waveSound.Play();
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (col == Physics2D.OverlapPoint(mousePos))
            {
                Vector3 vec3 = Input.mousePosition - screenPos;
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
                        hintsSound.Play();
                        hintsAppear.seenAmpl = true;
                        hintsAppear.hintsSpawned.Add(hintAmpl);
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
                        hintsSound.Play();
                        hintsAppear.seenFreq = true;
                        hintsAppear.hintsSpawned.Add(hintFreq);
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
            {
                waveSound.Stop();
            }

        if (sinewave.amplitude > (desiredAmpl - 0.2f) && sinewave.amplitude < (desiredAmpl + 0.2f) && sinewave.frequency > (desiredFreq - 2f) && sinewave.frequency < (desiredFreq + 2f))
        {
            Debug.Log("victory");
            
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

        if (hintsAppear.seenFreq == true && hintsAppear.seenAmpl == true && hintsAppear.seenSignal == false)
        {
            StartCoroutine(Signal());
        }

        float howClose = ((sinewave.amplitude / desiredAmpl) + (sinewave.frequency / desiredFreq) / 2);
        coolLight.intensity = Mathf.Lerp(maxInt, 0, howClose);
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
        hintsSound.Play();
        hintsAppear.seenSignal = true;

        if (signalAdded == false)
        {
            hintsAppear.hintsSpawned.Add(hintSignal);
            signalAdded = true;
        }
    }
}
