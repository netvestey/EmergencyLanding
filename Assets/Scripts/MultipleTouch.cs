using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTouch : MonoBehaviour
{
    public GameObject circle;
    public List<TouchLocation> touches = new List<TouchLocation>();


    void Start()
    {
        
    }
    void Update()
    {
        int n = 0;
        while (n < touches.Count)
        {
            Touch t = Input.GetTouch(n);
            if (t.phase == TouchPhase.Began)
            {
                Debug.Log("touch began");
                touches.Add(new TouchLocation(t.fingerId, createCircle(t)));
            }
            else if (t.phase == TouchPhase.Ended)
            {
                Debug.Log("touch ended");
            }

            else if (t.phase == TouchPhase.Moved)
            {
                Debug.Log("touch moved");
            }
            ++n;
        }

    }

    GameObject createCircle (Touch t)
    {
        GameObject c = Instantiate (circle) as GameObject;
        c.name = "Touch" + t.fingerId;
      
        return c;
    }

}
