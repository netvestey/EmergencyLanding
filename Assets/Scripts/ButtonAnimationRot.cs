using UnityEngine;

public class ButtonAnimationRot : MonoBehaviour {
    
    [SerializeField] float speed = 1;
    [SerializeField] float amplitude = 2;
    [SerializeField] bool isLeft;

    float baseRot;
    float delta;

    private void Start() {

        baseRot = transform.eulerAngles.z;
    }


    void Update() {

        if (isLeft)
        {
            delta = baseRot + amplitude * Mathf.Sin(Time.time * speed);
         }

        else
        {
            delta = baseRot - amplitude * Mathf.Sin(Time.time * speed);
        }

        transform.localRotation = Quaternion.Euler(0, 0, delta);


    }
}
