using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStateMachine<TStateType, TContext>: MonoBehaviour 
where TStateType : Enum
where TContext: struct
{
    [SerializeField] private TStateType initialState;
    protected TStateType InitialState => initialState;
    private BaseState<TStateType, TContext> currentState;
    public BaseState<TStateType, TContext> CurrentState => currentState;
    protected readonly Dictionary<TStateType, BaseState<TStateType, TContext>> states = new();
    public TContext context;

    protected abstract void Setup();

    virtual protected void Start()
    {
        Setup();
        currentState = states[initialState];
        foreach(var (stateName, state) in states)
        {
            state.OnChange += ChangeState;
        }
        states[initialState].Enter();
        
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
}
