using System;
using Unity.VisualScripting;
using UnityEngine;

namespace PlayerStates.States
{

    public class Idle : BaseState<PLAYER_STATE, PlayerContext>
    {
        public Idle(PLAYER_STATE id, PlayerContext context) : base(PLAYER_STATE.IDLE, context){}
        public override void Enter()
        {
            Debug.Log("Entering Idle State");
        }
    }


}

