using UnityEngine;

public abstract class Pickup: MonoBehaviour
{
    private EventManager eventManager;
    [SerializeField] private AudioClip pickupSound;
    public AudioClip PickupSound =>  pickupSound;
    private void Awake()
    {
        eventManager = EventManager.Instance;
    }
    public virtual void DestroySelf()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        OnPickup(otherCollider);
    }
    public virtual void OnPickup(Collider2D otherCollider)
    {
        InvokePickupEvent(otherCollider);
        DestroySelf();
    }
    public void InvokePickupEvent(Collider2D collider)
    {
        eventManager.InvokePickupEvent(gameObject, collider);
    }
}
