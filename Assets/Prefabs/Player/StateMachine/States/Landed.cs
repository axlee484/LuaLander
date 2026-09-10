using UnityEngine;

public class Landed : BaseState<PLAYER_STATE, PlayerContext>
{
    public Landed(PLAYER_STATE _id, PlayerContext _context) : base(_id, _context)
    {
    }
}
