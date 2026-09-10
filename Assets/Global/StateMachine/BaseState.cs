using System;
using UnityEngine;

public abstract class BaseState<TStateType, TContext> 
where TStateType : Enum
where TContext: struct
{
    private event Action<TStateType> OnChange;
    protected void InvokeOnChange(TStateType state)
    {
        OnChange?.Invoke(state);
    }
    private readonly TContext context;
    private readonly TStateType id;
    public TStateType Id => id;
    public TContext Context => context;

    public BaseState(TStateType _id, TContext _context)
    {
        id = _id;
        context = _context;
    }

    public virtual void Enter() {}
    public virtual void Exit() {}
    public virtual void Update() {}
    public virtual void FixedUpdate() {}
    
}
