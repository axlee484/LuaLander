using UnityEngine;

public class TimedPickup : Pickup
{
    [SerializeField] private float pickupTime = 3f;
    [SerializeField] private Timer pickupTimer;
    private Collider2D otherCollider;
    void Awake()
    {
        pickupTimer.CountDown = pickupTime;
        pickupTimer.TimeOut += OnTimeOut;
    }
    private void OnTimeOut()
    {
        InvokePickupEvent(otherCollider);
        DestroySelf();
    }

    public override void OnPickup(Collider2D otherCollider)
    {
        pickupTimer.StartTimer();
        this.otherCollider = otherCollider;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        pickupTimer.ResetTimer();
        print("Pickup reset");
    }
}
