using UnityEngine;

public class Landing : BaseState<PLAYER_STATE, PlayerContext>
{
    private Timer landingTimer;
    private PlayerController playerController;
    private float maxlandingAngleDegrees;
    private InputActions inputActions;
    private RigidBodyMovement movement;
    private bool isLanding = false;

    public Landing(PLAYER_STATE _id, PlayerContext _context) : base(_id, _context)
    {
        playerController = Context.playerController;
        maxlandingAngleDegrees = Context.playerController.MaxLandingAngleDegrees;

        movement = Context.movement;

        inputActions = GameInput.Instance.InputActions;

        landingTimer = playerController.LandingTimer;
        landingTimer.TimeOut += OnTimeOut;
    }

    private void OnTimeOut()
    {
        InvokeOnChange(PLAYER_STATE.LANDED);
    }

    private bool IsWithinLandingAngle(Collision2D collision)
    {
        var landingAngleDot = Vector2.Dot(collision.collider.transform.up, playerController.transform.up);
        var minLandingDot = Mathf.Cos(Mathf.Deg2Rad*maxlandingAngleDegrees);
        return landingAngleDot > minLandingDot;
    }

    public override void OnCollisionStay2D(Collision2D collision)
    {
        if(!collision.collider.TryGetComponent<LandingPad>(out var landingPad)) return;
        if(isLanding && !IsWithinLandingAngle(collision))
        {
            landingTimer.ResetTimer();
            isLanding = false;
            return;
        }
        
        if(IsWithinLandingAngle(collision) && !isLanding) 
        {
            landingTimer.StartTimer();
            isLanding = true;
        }
        
    }


    public override void OnCollisionExit2D(Collision2D collision)
    {
        if(!collision.collider.TryGetComponent<LandingPad>(out var landingPad)) return;

        InvokeOnChange(PLAYER_STATE.IDLE);
        landingTimer.ResetTimer();
        isLanding = false;
    }

    public override void Enter()
    {
        isLanding = false;
    }

    public override void FixedUpdate()
    {
        if(inputActions.Player.Up.WasPressedThisFrame() || inputActions.Player.Up.IsPressed())
        {
            InvokeOnChange(PLAYER_STATE.FLYING);
            return;
        }
        var tilt = inputActions.Player.Tilt.ReadValue<float>();
        if(tilt > 0) movement.Rotate(Vector2.right);
        if(tilt < 0) movement.Rotate(Vector2.left);
    }

    
}
