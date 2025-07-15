using UnityEngine;

public class ButtonAnimation : MonoBehaviour {

    [SerializeField] float speed = 1;
    [SerializeField] float amplitude = 2;

    float baseScale;

    private void Start() {

        baseScale = transform.localScale.x;
    }


    void Update() {


        float sin = Mathf.Sin(Time.time * speed);
        transform.localScale = (baseScale + amplitude * Mathf.Abs(sin)) * Vector3.one;
    }
}
