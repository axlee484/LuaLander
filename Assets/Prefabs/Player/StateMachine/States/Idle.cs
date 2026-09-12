using System;
using Unity.VisualScripting;
using UnityEngine;

namespace PlayerStates.States
{

    public class Idle : BaseState<PLAYER_STATE, PlayerContext>
    {
        private readonly InputActions InputActions;
        private readonly FuelManager fuelManager;
        private readonly RigidBodyMovement movement;
        public Idle(PLAYER_STATE id, PlayerContext context) : base(PLAYER_STATE.IDLE, context)
        {
            InputActions = GameInput.Instance.InputActions;
            fuelManager = Context.fuelManager;
            movement = Context.movement;
        }

        
        private void CheckFlying()
        {
            if(!movement.IsControlEnabled) return;
            if(fuelManager.FuelRemaning<=0) return;
            
            if(InputActions.Player.Up.WasPressedThisFrame() || InputActions.Player.Up.IsPressed())
            {
                InvokeStateChange(PLAYER_STATE.FLYING);
                return;
            }
            if(Math.Abs(InputActions.Player.Tilt.ReadValue<float>()) > 0)
            {
                InvokeStateChange(PLAYER_STATE.FLYING);
                return;
            }
        }
        
        public override void FixedUpdate()
        {
            CheckFlying();
        }

        public override void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.collider.TryGetComponent<LandingPad>(out var landingPad))
            {
                Context.CurrentLandingPad = landingPad;
                InvokeStateChange(PLAYER_STATE.LANDING);
            }
        }
    }


}

