using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStateMachine<TStateType, TContext>: MonoBehaviour 
where TStateType : Enum
where TContext: struct
{
    [SerializeField] private TStateType initialStateId;
    protected TStateType InitialState => initialStateId;
    private BaseState<TStateType, TContext> currentState;
    public BaseState<TStateType, TContext> CurrentState => currentState;
    protected readonly Dictionary<TStateType, BaseState<TStateType, TContext>> states = new();
    public TContext context;

    protected abstract void Setup();

    virtual protected void Start()
    {
        Setup();
        currentState = states[initialStateId];
        foreach(var (stateName, state) in states)
        {
            state.OnChange += ChangeState;
        }
        states[initialStateId].Enter();
        
    }

    void Update()
    {
        currentState.Update();
    }

    void FixedUpdate()
    {
        currentState.FixedUpdate();
    }

    public void ChangeState(TStateType nextState)
    {
        currentState.Exit();
        currentState = states[nextState];
        currentState.Enter();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollisionEnter2D(collision);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        currentState.OnCollisionStay2D(collision);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        currentState.OnCollisionExit2D(collision);
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        currentState.OnTriggerEnter2D(otherCollider);
    }
    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        currentState.OnTriggerStay2D(otherCollider);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        currentState.OnTriggerExit2D(collision);
    }
}
