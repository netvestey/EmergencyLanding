using System.Collections;
using UnityEngine;

public class Rotators : MonoBehaviour
{
    private Camera cam;
    private Vector3 screenPos;
    private float angleOffset;
    private Collider2D col;

    public Sinewave sinewave;
    public Sinewave desiredsine;
    private float desiredAmpl;
    private float desiredFreq;

    private readonly float minAmpl = 0.1f;
    private readonly float maxAmpl = 1;
    private readonly float minFreq = 0.5f;
    private readonly float maxFreq = 10;

    private float minPitch;
    private float maxPitch;
    private float minRev;
    private float maxRev;

    [SerializeField] bool isAmpl;
    private float progress;

    public GameObject sounds;
    private AudioSource waveSound;

    public Messages messages;
    public Hints hints;

    public Settings settings;

    private void Start()
    {
        cam = Camera.main;
        col = GetComponent<Collider2D>();
        desiredAmpl = desiredsine.amplitude;
        desiredFreq = desiredsine.frequency;

        AudioSource[] allAudioSources = sounds.GetComponents<AudioSource>();
        waveSound = allAudioSources[0];
        minPitch = waveSound.pitch * 0.5f;
        maxPitch = waveSound.pitch * 2f;
        minRev = waveSound.reverbZoneMix * 0.5f;
        maxRev = waveSound.reverbZoneMix * 2f;
    }

    private void Update()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && !settings.isPaused)
        {
            if (col == Physics2D.OverlapPoint(mousePos))
            {
                screenPos = cam.WorldToScreenPoint(transform.position);
                Vector3 vecm3 = Input.mousePosition - screenPos;
                angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(vecm3.y, vecm3.x)) * Mathf.Rad2Deg;

                waveSound.Play();
            }
        }

        if (Input.GetMouseButton(0) && !settings.isPaused)
        {
            if (col == Physics2D.OverlapPoint(mousePos))
            {
                Vector3 vecm3 = Input.mousePosition - screenPos;
                float anglem = Mathf.Atan2(vecm3.y, vecm3.x) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, 0, anglem + angleOffset);
                progress = transform.eulerAngles.z / 360f * 2;
                progress = Mathf.PingPong(progress, 1);


                if (isAmpl)
                {
                    sinewave.amplitude = Mathf.Lerp(minAmpl, maxAmpl, progress);
                    waveSound.pitch = Mathf.Lerp(maxPitch, minPitch, progress);

                    if (!hints.spawned.Contains(hints.ampl))
                    {
                        hints._text.text = hints.ampl;
                        hints.arrows.SetActive(true);
                        hints.spawned.Add(hints.ampl);
                    }
                }

                else
                {
                    sinewave.frequency = Mathf.Lerp(maxFreq, minFreq, progress);
                    waveSound.reverbZoneMix = Mathf.Lerp(maxRev, minRev, progress);

                    if (!hints.spawned.Contains(hints.freq))
                    {
                        hints._text.text = hints.freq;
                        hints.arrows.SetActive(true);
                        hints.spawned.Add(hints.freq);
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
            waveSound.Stop();

        if (sinewave.amplitude > (desiredAmpl - 0.1f) && sinewave.amplitude < (desiredAmpl + 0.1f) && sinewave.frequency > (desiredFreq - 1f) && sinewave.frequency < (desiredFreq + 1f))
        {
            if (settings.isLastLevel)
                settings.isGameWon = true;

            StartCoroutine(HasWon());
        }
    }

    IEnumerator HasWon()
    {
        settings.isPaused = true;

        sinewave.frequency = Mathf.Lerp(sinewave.frequency, desiredFreq, 2 * Time.deltaTime);
        sinewave.amplitude = Mathf.Lerp(sinewave.amplitude, desiredAmpl, 2 * Time.deltaTime);

        yield return new WaitForSeconds(2);

        if (settings.isUIVisible)
        {
            messages.ShowMessage();
            settings.isUIVisible = false;
        }
    }
}
