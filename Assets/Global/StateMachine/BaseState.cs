using System;
using UnityEngine;

public abstract class BaseState<TStateType, TContext> 
where TStateType : Enum
{
    public event Action<TStateType> StateChange;
    protected void InvokeStateChange(TStateType state)
    {
        StateChange?.Invoke(state);
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
    public virtual void OnCollisionEnter2D(Collision2D collision) {}
    public virtual void OnCollisionStay2D(Collision2D collision) {}
    public virtual void OnCollisionExit2D(Collision2D collision) {}
    public virtual void OnTriggerEnter2D(Collider2D otherCollider) {}
    public virtual void OnTriggerStay2D(Collider2D otherCollider) {}
    public virtual void OnTriggerExit2D(Collider2D collision) {}

    
}
