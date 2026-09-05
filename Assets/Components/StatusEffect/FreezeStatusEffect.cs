using System;
using UnityEngine;


[Serializable]
public class FreezeStatusEffect : BaseStatusEffect
{
    public override STATUS_EFFECT_TYPE StatusEffectType => STATUS_EFFECT_TYPE.FREEZE;
    [SerializeField] private float duration = 5f;

    [Range(0f, 1f)]
    [SerializeField] private float intensity = 0.5f;

    public override void ApplyEffect(GameObject target)
    {
        base.ApplyEffect(target);
        target.TryGetComponent(out IMovement movement);
        movement.SlowDown(intensity);
    }

    public override void RemoveEffect(GameObject target)
    {
        target.TryGetComponent(out IMovement movement);
        movement.Boost(intensity);
    }

}


