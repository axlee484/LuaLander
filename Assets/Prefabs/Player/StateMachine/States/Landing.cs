using UnityEngine;

public class Landing : BaseState<PLAYER_STATE, PlayerContext>
{
    private PlayerController playerController;
    private float maxlandingAngleDegrees;
    private InputActions inputActions;
    private RigidBodyMovement movement;
    private bool isLanding = false;
    private LandingPad landingPad;

    public Landing(PLAYER_STATE _id, PlayerContext _context) : base(_id, _context)
    {
        playerController = Context.playerController;
        movement = Context.movement;

        inputActions = GameInput.Instance.InputActions;
    }

    private void OnTimeOut()
    {
        InvokeStateChange(PLAYER_STATE.LANDED);
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
            landingPad.LandingTimer.ResetTimer();
            isLanding = false;
            return;
        }
        
        if(IsWithinLandingAngle(collision) && !isLanding) 
        {
            landingPad.LandingTimer.StartTimer();
            isLanding = true;
        }
        
    }


    public override void OnCollisionExit2D(Collision2D collision)
    {
        if(!collision.collider.TryGetComponent<LandingPad>(out var landingPad)) return;
        InvokeStateChange(PLAYER_STATE.IDLE);
        
    }

    public override void Enter()
    {
        landingPad = Context.CurrentLandingPad;
        maxlandingAngleDegrees = Context.CurrentLandingPad.MaxLandingAngleDegrees;
        landingPad.LandingTimer.TimeOut += OnTimeOut;
        isLanding = false;
    }

    public override void FixedUpdate()
    {
        if(inputActions.Player.Up.WasPressedThisFrame() || inputActions.Player.Up.IsPressed())
        {
            InvokeStateChange(PLAYER_STATE.FLYING);
            return;
        }
        var tilt = inputActions.Player.Tilt.ReadValue<float>();
        if(tilt > 0) movement.Rotate(Vector2.right);
        if(tilt < 0) movement.Rotate(Vector2.left);
    }

    public override void Exit()
    {
        landingPad.LandingTimer.ResetTimer();
        isLanding = false;
        landingPad.LandingTimer.TimeOut -= OnTimeOut;
        Context.CurrentLandingPad = null;
    }

    
}
