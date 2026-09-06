using UnityEngine;

public  class Pickable : MonoBehaviour
{
    public virtual void DestroySelf()
    {
        Destroy(gameObject);
    }
    public virtual void PickUp(Collider2D otherCollider)
    {
        DestroySelf();
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        PickUp(otherCollider);
    }
}
