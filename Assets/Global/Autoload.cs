using UnityEngine;

public static class Autoload
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void InitializeAutoloads()
    {
        var prefab = Resources.Load<GameObject>("Autoload");
        var autoLoad = Object.Instantiate(prefab);
        Object.DontDestroyOnLoad(autoLoad);
    }
}
