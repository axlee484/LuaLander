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

        private Vector2 GetTiltInput()
        {
            var tilt = InputActions.Player.Tilt.ReadValue<float>();
            if(tilt > 0) return Vector2.right;
            if(tilt < 0) return Vector2.left;
            return Vector2.zero;
        }
        private void Fly()
        {
            var linearInput = InputActions.Player.Up;
            var tiltInput = GetTiltInput();

            
            if (linearInput.IsPressed())
            {
                movement.Move(playerTransform.up);
            }
            movement.Rotate(tiltInput);
            if(!linearInput.IsPressed() && tiltInput == Vector2.zero) 
            {
                InvokeOnChange(PLAYER_STATE.IDLE);
                return;
            }              
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