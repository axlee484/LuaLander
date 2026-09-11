using PlayerStates.States;
using UnityEngine;

public enum PLAYER_STATE
{
    IDLE,
    FLYING,
    LANDING,
    LANDED
}
public struct PlayerContext
{
    public PlayerController playerController;
    public PlayerVisuals playerVisuals;
    public Rigidbody2D playerBody;
    public Health health;
    public FuelManager fuelManager;
    public RigidBodyMovement movement;
    public Transform playerTransform;
};

[
RequireComponent(typeof(PlayerController)),
RequireComponent(typeof(Rigidbody2D)), 
RequireComponent(typeof(Health)), 
RequireComponent(typeof(FuelManager)), 
RequireComponent(typeof(RigidBodyMovement)),
RequireComponent(typeof(PlayerVisuals))
]
public class PlayerStateMachine : BaseStateMachine<PLAYER_STATE, PlayerContext>
{
    protected override void Setup()
    {
        context = new PlayerContext {
            playerController = GetComponent<PlayerController>(),
            playerBody = GetComponent<Rigidbody2D>(),
            health = GetComponent<Health>(),
            fuelManager = GetComponent<FuelManager>(),
            movement = GetComponent<RigidBodyMovement>(),
            playerTransform = GetComponent<Transform>(),
            playerVisuals = GetComponent<PlayerVisuals>(),
        };
        
        var idleState = new Idle(PLAYER_STATE.IDLE, context);
        var flyingState = new Flying(PLAYER_STATE.FLYING, context);
        var landingState = new Landing(PLAYER_STATE.LANDING, context);
        var landedState = new Landed(PLAYER_STATE.LANDED, context);
        
        states.Add(PLAYER_STATE.IDLE, idleState);
        states.Add(PLAYER_STATE.FLYING, flyingState);
        states.Add(PLAYER_STATE.LANDING, landingState);
        states.Add(PLAYER_STATE.LANDED, landedState);
    } 
    
    
    
}
