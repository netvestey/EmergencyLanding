using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private Image image;
    
    private void Start()
    {
     
        Color color = image.color;
        color.a = 1;
        image.color = color;
        StartCoroutine(ChangeAlpha(0.2f, 0, null));
    }
    
    public void ChangeScene()
    {
        void Finished()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        StartCoroutine(ChangeAlpha(0.2f, 1, Finished));
    }

    IEnumerator ChangeAlpha(float duration, float target, Action finished)
    {
        float time = 0;
        float sourceAlpha = image.color.a;
        
        Color color;
        
        while (time < duration)
        {
            yield return null;
            time += Time.deltaTime;

            float phase = time / duration;

            color = image.color;
            color.a = Mathf.Lerp(sourceAlpha, target, phase);
            image.color = color;
        }
        
        color = image.color;
        color.a = target;
        image.color = color;
        
        finished?.Invoke();
    }

}
