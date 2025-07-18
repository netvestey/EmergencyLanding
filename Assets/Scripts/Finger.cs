using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finger : MonoBehaviour
    
{
    public GameObject finger;
    private float inputTimer;
    private bool isPlaying = false;
    public Settings settings;

    void Update()
    {
        inputTimer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) || settings.isVideoPlaying)
        {
            inputTimer = 0;
            finger.SetActive(false);
        }

        if (inputTimer >= 5f && !isPlaying && !settings.isPaused)
        {
            StartCoroutine(TappingFinger());
            isPlaying = true;
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
