using UnityEngine;

public class HintsSpawner : MonoBehaviour
{
    public Hints hint;
    public GameObject arrows;
    public Settings settings;

    public void HintSpawner()
    {
        if (settings.isFirstLevel && !settings.isLevelWon)
        {
            hint.spawned.Add(hint.signal);
            hint._text.text = hint.signal;
        }
        else if (!settings.isFirstLevel && !settings.isLevelWon)
        {
            hint.spawned.Add(hint.signal);
            hint.spawned.Add(hint.ampl);
            hint.spawned.Add(hint.freq);
            hint._text.text = hint.signal;
            arrows.SetActive(true);
        }
    }
}
