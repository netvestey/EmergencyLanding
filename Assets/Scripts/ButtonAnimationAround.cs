using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ButtonAnimationAround : MonoBehaviour {
    
    [SerializeField] float speed = 1;
    [SerializeField] float direction = 1;

    void Update() {

        transform.RotateAround(transform.position, new Vector3(0, 0, -90 * direction), speed * Time.deltaTime);
    }
}
