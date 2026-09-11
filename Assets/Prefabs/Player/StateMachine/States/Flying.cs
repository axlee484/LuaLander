using Mono.Cecil.Cil;
using UnityEngine;

namespace PlayerStates.States
{
    public class Flying : BaseState<PLAYER_STATE, PlayerContext>
    {
        private readonly RigidBodyMovement movement;
        private readonly InputActions InputActions; 
        private readonly FuelManager fuelManager;
        private readonly Transform playerTransform;
        private readonly PlayerVisuals playerVisuals;
        public Flying(PLAYER_STATE _id, PlayerContext _context) : base(_id, _context)
        {
            movement = Context.movement;
            InputActions = GameInput.Instance.InputActions;
            fuelManager = Context.fuelManager;
            playerTransform = Context.playerTransform;
            playerVisuals = Context.playerVisuals;
        }

        
        private void Fly()
        {  
            var linearInput = InputActions.Player.Up.IsPressed();    
            var tilt = InputActions.Player.Tilt.ReadValue<float>();
            if(!linearInput && tilt == 0)
            {
                InvokeOnChange(PLAYER_STATE.IDLE);
                return;
            }
            
            movement.Move(playerTransform.up);
            if(tilt > 0) movement.Rotate(Vector2.right);
            if(tilt < 0) movement.Rotate(Vector2.left);
            

        }

        public override void Enter()
        {
            playerVisuals.PlayAllThrustParticles(true);
        }

        public override void Exit()
        {
            playerVisuals.PlayAllThrustParticles(false);
        }
        public override void FixedUpdate()
        {
            Fly();
        }
    }

}