using UnityEngine;

namespace PlayerStates.States
{
    public class Flying : BaseState<PLAYER_STATE, PlayerContext>
    {
        public Flying(PLAYER_STATE _id, PlayerContext _context) : base(_id, _context)
        {
        }
    }

}