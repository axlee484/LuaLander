using UnityEngine;

public enum SCENE_TYPE
{
    MAIN_SCENE,
    GAME_SCENE,
}
public class SceneManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static SceneManager Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(SCENE_TYPE scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)scene);
    }
}
