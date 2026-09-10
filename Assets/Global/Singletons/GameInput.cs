using UnityEngine;

public class GameInput : MonoBehaviour
{
    private InputActions inputActions;
    public InputActions InputActions => inputActions;
    public static GameInput Instance;

    private void Awake()
    {
        Instance = this;
        inputActions = new InputActions();
        DontDestroyOnLoad(gameObject);
    }
}
