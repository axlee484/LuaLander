using UnityEngine;

namespace PlayerStates.States
{
    public class Flying : BaseState<PLAYER_STATE, PlayerContext>
    {
        private readonly RigidBodyMovement movement;
        private readonly InputActions InputActions; 
        private readonly FuelManager fuelManager;
        private readonly Transform playerTransform;
        public Flying(PLAYER_STATE _id, PlayerContext _context) : base(_id, _context)
        {
            movement = Context.movement;
            InputActions = GameInput.Instance.InputActions;
            fuelManager = Context.fuelManager;
        }

        public override void Enter()
        {
            Debug.Log("Entering Flying State");
        }
    }

}