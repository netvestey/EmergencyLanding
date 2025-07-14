using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchLocation 
{
    public int touchId;
    public GameObject circle;

    public TouchLocation(int newTouchid, GameObject newCircle)
    {
        touchId = newTouchid; 
        circle = newCircle;
    }

}
