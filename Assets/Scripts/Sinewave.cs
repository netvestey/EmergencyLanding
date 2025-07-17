using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinewave: MonoBehaviour
{
    public LineRenderer coolLine;
    public int points;
    public float amplitude = 1;
    public float frequency = 1;
    public Vector2 xLimits = new Vector2(0, 1);
    public float movementSpeed = 1;

    public Settings settings;

    void Start()
    {
        coolLine = GetComponent<LineRenderer>();
    }

    void Draw()
    {
        float xStart = xLimits.x;
        float Tau = 2 * Mathf.PI;
        float xFinish = xLimits.y;

        coolLine.positionCount = points;
        for (int currentPoint = 0; currentPoint < points; currentPoint++)
        {
            float progress = (float)currentPoint / (points - 1);
            float x = Mathf.Lerp(xStart, xFinish, progress);
            float y = amplitude * Mathf.Sin((Tau * frequency * progress) + Time.timeSinceLevelLoad * movementSpeed);

            coolLine.SetPosition(currentPoint, new Vector3(x, y, 0));
        }
    }

    void Update()
    { 
        if (settings.isLevelStart && !settings.isLevelWon)
        {
            Draw();
        }
    }
}
