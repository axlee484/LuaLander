using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private RigidBodyMovement movement;
    [SerializeField] private Health health;
    [SerializeField] private HurtBox hurtBox;
    [SerializeField] private HitBox hitBox;
    private Timer landingTimer;
    private bool isLanding = false;


    private void Awake()
    {
        landingTimer = GetComponent<Timer>();
        landingTimer.OnTimeOut += FinishLanding;
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


    private void FinishLanding()
    {
        isLanding = false;
        print("Landed");
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<LandingPad>(out var _))
        {
            landingTimer.StartTimer();
            print("Landing Start");
        }
    
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<LandingPad>(out var _))
        {
            isLanding = true;
            landingTimer.Reset();
        }
        
    }

    void Update()
    {
        GetInput();
    }
}
