using System;
using System.Collections;
using UnityEngine;


[Serializable]
public abstract class BaseStatusEffect
{
    private readonly STATUS_EFFECT_TYPE statusEffectType;
    public virtual STATUS_EFFECT_TYPE StatusEffectType => statusEffectType;
    [SerializeField] private float statusDuration = 0f;
    public virtual float StatusDuration => statusDuration;
    [SerializeField] private float baseDamage = 0f;
    public virtual float BaseDamage => baseDamage;
    public event Action<BaseStatusEffect> OnRemoved;

    protected virtual void InvokeOnRemoved()
    {
        OnRemoved?.Invoke(this);
    }

    public virtual IEnumerator StatusEffectCoroutine()
    {
        yield return new WaitForSeconds(StatusDuration);
        InvokeOnRemoved();
    }
    public virtual void ApplyEffect(GameObject target)
    {
        target.TryGetComponent(out Health health);
        health.TakeDamage(BaseDamage);
    }
    public virtual void UpdateEffect(GameObject target){}
    public virtual void RemoveEffect(GameObject target){}
}


