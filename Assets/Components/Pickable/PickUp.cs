using UnityEngine;

public  class PickUp : MonoBehaviour
{
    public virtual void DestroySelf()
    {
        Destroy(gameObject);
    }
    public virtual void OnPickUp(Collider2D otherCollider)
    {
        DestroySelf();
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        OnPickUp(otherCollider);
    }
}
