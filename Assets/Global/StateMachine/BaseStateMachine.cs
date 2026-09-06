using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStateMachine<TStateType>: MonoBehaviour where TStateType : Enum
{
    
    [SerializeField] private IState<TStateType> initialState;
    private IState<TStateType> currentState;
    private readonly Dictionary<TStateType, IState<TStateType>> states;

    void Awake()
    {
        var states = GetComponents<IState<TStateType>>();
        foreach (var state in states)
        {
            this.states.Add(state.Name, state);
            state.ChangeState += ChangeState;
        }
        currentState = initialState;
    }
    public void Initialize()
    {
        initialState.Enter();
    }

    void Update()
    {
        currentState.Update();
    }

    void FixedUpdate()
    {
        currentState.FixedUpdate();
    }

    void ChangeState(TStateType nextState)
    {
        currentState.Exit();
        currentState = states[nextState];
        currentState.Enter();
    }
}
