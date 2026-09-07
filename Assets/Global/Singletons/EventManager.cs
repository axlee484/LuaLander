using System;
using UnityEngine;

public class EventManager: MonoBehaviour
{
    public event Action<Coin, Collider2D> CoinPickupEvent;
    public event Action<Fuel, Collider2D> FuelPickupEvent;
    public void InvokePickupEvent(GameObject sender, Collider2D otherCollider)
    {
        if(sender.TryGetComponent<Coin>(out var coin)) 
        {
            CoinPickupEvent?.Invoke(coin, otherCollider);
            return;
        }
        if(sender.TryGetComponent<Fuel>(out var fuel))
        {
            FuelPickupEvent?.Invoke(fuel, otherCollider);
        }
    }
    public static EventManager Instance;
    
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
