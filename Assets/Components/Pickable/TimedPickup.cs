using UnityEngine;

public class TimedPickup : MonoBehaviour, IPickable
{
    [SerializeField] private float pickupTime = 5f;
    [SerializeField] private Timer pickupTimer;
    void Awake()
    {
        pickupTimer.TimeOut = pickupTime;
        pickupTimer.OnTimeOut += DestroySelf;
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D otherCollider)
    {
        pickupTimer.StartTimer();
        print("Pickup triggered");
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        pickupTimer.ResetTimer();
        print("Pickup reset");
    }
}
