using UnityEngine;

public static class Autoload
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void InitializeAutoloads()
    {
        Debug.Log("AUTOLOAD INITIALIZED");
        var autoLoad = new GameObject("autoload");
        autoLoad.AddComponent<GameInput>();
        autoLoad.AddComponent<AudioManager>();
        autoLoad.AddComponent<EventManager>();
        autoLoad.AddComponent<ScoreManager>();
        autoLoad.AddComponent<LevelManager>();
        autoLoad.AddComponent<SceneManager>();
        autoLoad.AddComponent<GameManager>();
        Object.DontDestroyOnLoad(autoLoad);

    }
}
