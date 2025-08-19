using System.Collections;
using UnityEngine;

public class Finger : MonoBehaviour
    
{
    public GameObject finger;
    private float inputTimer;
    private bool isPlaying = false;
    public Settings settings;

    void Update()
    {
        if (!settings.isPaused)
            inputTimer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            inputTimer = 0;
            finger.SetActive(false);
            isPlaying = true; 
        }

        if (inputTimer >= 5f && !isPlaying && !settings.isPaused)
        {
            isPlaying = true;
            StartCoroutine(TappingFinger());
        }

        else if (inputTimer >= 31f)
        {
            StartCoroutine(TappingFinger());
            inputTimer = 0;
        }
    }


    IEnumerator TappingFinger()
    {
        finger.SetActive(true);
        finger.GetComponent<Animator>().Play("MovingFinger");
        yield return new WaitForSeconds(3.5f);
        finger.SetActive(false);
    }


}
