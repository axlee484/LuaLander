using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
