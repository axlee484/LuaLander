using System.Collections;
using System.Reflection.Metadata;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private RigidBodyMovement movement;
    [SerializeField] private Health health;
    [SerializeField] private HurtBox hurtBox;
    [SerializeField] private HitBox hitBox;
    [SerializeField] private Timer landingTimer;
    [Range(0f, 180f)]
    [SerializeField] private float maxlandingAngleDegrees = 5f;

    void Start()
    {
        landingTimer.OnTimeOut += OnLandingTimeOut;
    }
    void OnLandingTimeOut()
    {
        print("Landed");
    }

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

    private bool IsWithinLandingAngle(Collision2D collision)
    {
        var landingAngleDot = Vector2.Dot(collision.collider.transform.up, transform.up);
        var minLandingDot = Mathf.Cos(Mathf.Deg2Rad*maxlandingAngleDegrees);
        return landingAngleDot > minLandingDot;
    }


    private void HandleLandingPad(Collision2D collision)
    {
        if(health.CurrentHealth <= 0) return;
        if(!IsWithinLandingAngle(collision)) return;

        landingTimer.StartTimer();
        print("Landing Started");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<LandingPad>(out var _))
        {
            HandleLandingPad(collision);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(!collision.gameObject.TryGetComponent<LandingPad>(out var _)) return;
        
        if(!IsWithinLandingAngle(collision)) {
            landingTimer.ResetTimer();
            print("Toppled");
            return;
        }
        if(landingTimer.enabled) return;
        HandleLandingPad(collision);
        
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<LandingPad>(out var landingPad))
        {
            print("Landing failed Collision Exit");
            landingTimer.ResetTimer();
        }
    }


    void Update()
    {
        GetInput();
    }
}
