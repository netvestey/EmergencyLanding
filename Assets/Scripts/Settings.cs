using UnityEngine;

public class Settings : MonoBehaviour

{
    public bool isPaused;
    public bool isUIVisible;
    public bool isLevelWon; 
    public bool isGameWon;
    public bool isLevelStart;
    public bool isFirstLevel;
    public bool isLastLevel;
    void Start()
    {
        Screen.SetResolution(3840, 2160, true);
    }
}
