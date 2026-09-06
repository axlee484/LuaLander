using UnityEngine;

public  class InstantPickable : MonoBehaviour, IPickable
{
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        OnPickup(otherCollider);
    }
    public void OnPickup(Collider2D otherCollider)
    {
        DestroySelf();
    }
}
