using UnityEngine;

public class HintsSpawner : MonoBehaviour
{
    public Hints hint;
    public GameObject arrows;
    public Settings settings;

    public void FirstLevelSpawner()
    {
        hint.spawned.Add(hint.signal);
        hint._text.text = hint.signal; 
    }

    public void NextLevelSpawner()
    {
        hint.spawned.Add(hint.signal);
        hint.spawned.Add(hint.ampl);
        hint.spawned.Add(hint.freq);
        hint._text.text = hint.signal;
        arrows.SetActive(true);
    }
}
