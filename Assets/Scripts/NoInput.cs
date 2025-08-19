using UnityEngine;
using UnityEngine.SceneManagement;

public class NoInput : MonoBehaviour
{
    private float inputTimer;

    void Update()
    {
        inputTimer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            inputTimer = 0;
        }

        if (inputTimer >= 60f)
        {
            SceneManager.LoadScene("StartScreen");
        }
    }
}
