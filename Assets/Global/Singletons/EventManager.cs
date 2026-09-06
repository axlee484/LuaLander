using System;
using UnityEngine;

public class EventManager: MonoBehaviour
{
    public event Action<Collider2D> PickupEvent;
    public void InvokePickupEvent(Collider2D collider)
    {
        PickupEvent?.Invoke(collider);
    }
    public static EventManager Instance;
    
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        print("EventManager instance + "+ Instance);
    }
}
