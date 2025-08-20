using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]

public class InputManager : Singleton<InputManager>
{
    public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnStartTouch;
    public delegate void EndTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnEndTouch;

    private TouchandMouseControls controls;

    private void Awake()
    {
        controls = new TouchandMouseControls();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Start()
    {
        controls.Touch.TouchPress.started += ctx => StartTouch(ctx);
        controls.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        OnStartTouch?.Invoke(controls.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.startTime);
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        OnEndTouch?.Invoke(controls.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.time);
    }
}
