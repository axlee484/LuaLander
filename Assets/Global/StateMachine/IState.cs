using System;
using UnityEngine;

public interface IState<TStateType>
{
    public event Action<TStateType> ChangeState;
    public TStateType Name {get; set;}
    public void Enter();
    public void Exit();
    public void Update();
    public void FixedUpdate();
    
}
