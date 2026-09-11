using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    private InputActions inputActions;
    public InputActions InputActions => inputActions;
    public static GameInput Instance;

    private void Awake()
    {
        Instance = this;
        inputActions = new InputActions();
        inputActions.Enable();
        DontDestroyOnLoad(gameObject);
    }

    public bool IsPressed(InputAction action)
    {
        return action.IsPressed();
    }

    public bool WasPressedThisFrame(InputAction action)
    {
        return action.WasPressedThisFrame();
    }

    public float GetAxis(InputAction action)
    {
        return action.ReadValue<float>();
    }
}
