using System;
using UnityEngine;

public class EventManager: MonoBehaviour
{
    public event Action<GameObject, Collider2D> PickupEvent;
    public void InvokePickupEvent(GameObject sender, Collider2D otherCollider)
    {
        PickupEvent?.Invoke(sender, otherCollider);
    }
    public static EventManager Instance;
    
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
