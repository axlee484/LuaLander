using UnityEngine;

public abstract class Pickup: MonoBehaviour
{
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
        DestroySelf();
    }
}
