using System;
using UnityEngine;


[Serializable]
public class ParalyzeStatusEffect : BaseStatusEffect
{
    public override STATUS_EFFECT_TYPE StatusEffectType => STATUS_EFFECT_TYPE.PARALYZE;
    public override void ApplyEffect(GameObject target)
    {
        target.TryGetComponent<IMovement>(out var movement);
        movement.IsControlEnabled = false;
    }
    public override void RemoveEffect(GameObject target)
    {
        target.TryGetComponent<IMovement>(out var movement);
        movement.IsControlEnabled = true;
    }
}


