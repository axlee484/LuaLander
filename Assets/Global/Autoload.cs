using UnityEngine;

public static class Autoload
{
    [RuntimeInitializeOnLoadMethod]
    public static void InitializeAutoloads()
    {
        var autoloadNode = new GameObject("Autoload");
        Object.DontDestroyOnLoad(autoloadNode);
        autoloadNode.AddComponent<EventManager>();
        autoloadNode.AddComponent<ScoreManager>();
        autoloadNode.AddComponent<GameManager>();
    }
}
