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
        private readonly Transform playerTransform;
        public Idle(PLAYER_STATE id, PlayerContext context) : base(PLAYER_STATE.IDLE, context)
        {
            InputActions = GameInput.Instance.InputActions;
            fuelManager = Context.fuelManager;
            movement = Context.movement;
            playerTransform = Context.playerTransform;
        }

        
        private void CheckFlying()
        {
            if(!movement.IsControlEnabled) return;
            if(fuelManager.FuelRemaning<=0) return;
            
            if(InputActions.Player.Up.IsPressed())
            {
                InvokeOnChange(PLAYER_STATE.FLYING);
                return;
            }
        }
        public override void Enter()
        {
            if(movement.LinearVelocity.magnitude > 0 || movement.AngularVelocity > 0) CheckFlying();
        }
        public override void FixedUpdate()
        {
            CheckFlying();
        }
    }


}

