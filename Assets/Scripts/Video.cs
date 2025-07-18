using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    public VideoPlayer VideoPlayer;
    public ButtonScript trans;
    public Settings settings;

    public AudioSource sound;

    void Start()
    {
        {
            VideoPlayer.loopPointReached += LoadScene;
        }
        void LoadScene(VideoPlayer vp)
        {
            trans.NextLevel();
        }
    }

    void PlayVideo()
    {
        sound.GetComponent<AudioSource>().Stop();
        VideoPlayer.Play();
        settings.isVideoPlaying = true;
    }
}
    
