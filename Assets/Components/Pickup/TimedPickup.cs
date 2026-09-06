using UnityEngine;

public class TimedPickup : Pickup
{
    [SerializeField] private float pickupTime = 5f;
    [SerializeField] private Timer pickupTimer;
    void Awake()
    {
        pickupTimer.TimeOut = pickupTime;
        pickupTimer.OnTimeOut += DestroySelf;
    }
    public override void OnPickup(Collider2D otherCollider)
    {
        pickupTimer.StartTimer();
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        pickupTimer.ResetTimer();
        print("Pickup reset");
    }
}
