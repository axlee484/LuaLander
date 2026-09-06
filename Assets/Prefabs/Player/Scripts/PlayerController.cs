using System.Collections;
using System.Reflection.Metadata;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private RigidBodyMovement movement;
    [SerializeField] private Health health;
    [SerializeField] private HurtBox hurtBox;
    [SerializeField] private HitBox hitBox;
    [SerializeField] private float maxSafeImpactSpeed = 10f;
    [SerializeField] private float damagePerImpactSpeed = 10f;


    


    private void GetInput()
    {
        if(Keyboard.current.wKey.isPressed)
        {
            movement.Move(transform.up);
        }
        if(Keyboard.current.aKey.isPressed)
        {
           movement.Rotate(Vector2.left);
        }
        else if(Keyboard.current.dKey.isPressed)
        {
            movement.Rotate(Vector2.right); 
        }
    }


    private float GetCollisionImpact(Collision2D collision)
    {
        // print("Collision impact: "+collision.relativeVelocity.magnitude);
        if(collision.relativeVelocity.magnitude <= maxSafeImpactSpeed) return 0;
        var excessSpeed = collision.relativeVelocity.magnitude - maxSafeImpactSpeed;
        return damagePerImpactSpeed*excessSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var impact = GetCollisionImpact(collision);
        health.TakeDamage(impact);
    }

    
    void Update()
    {
        GetInput();
    }
}
