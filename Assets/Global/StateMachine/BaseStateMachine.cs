using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStateMachine<TStateType, TContext>: MonoBehaviour 
where TStateType : Enum
where TContext: struct
{
    [SerializeField] private TStateType initalState;
    protected TStateType InitialState => initalState;
    private BaseState<TStateType, TContext> currentState;
    protected readonly Dictionary<TStateType, BaseState<TStateType, TContext>> states = new();
    public TContext context;

    protected abstract void Setup();

    virtual protected void Awake()
    {
        Setup();
        currentState = states[initalState];
        foreach(var (stateName, state) in states)
        {
            state.OnChange += ChangeState;
        }
        
    }
    public void Start()
    {
        currentState.Enter();
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
