using UnityEngine;

public interface IPickable
{
    public void DestroySelf();
    public void OnPickup(Collider2D otherCollider)
    {
        DestroySelf();
    }
}
