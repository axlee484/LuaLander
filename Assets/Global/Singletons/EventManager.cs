using System;
using UnityEngine;

public class EventManager: MonoBehaviour
{
    private event Action<Collider2D> PickedUp;
    public static EventManager Instance;
    
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
