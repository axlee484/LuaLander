using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float value;
    public event Action<Collider2D> CoinCollected;
   
    void OnTriggerEnter2D(Collider2D collider)
    {
        CoinCollected?.Invoke(collider);
    }

}
