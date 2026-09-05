using System;
using UnityEngine;


[Serializable]
public class BurnStatusEffect : BaseStatusEffect
{
    [SerializeField] private float damagePerSecond = 1f;
    public override STATUS_EFFECT_TYPE StatusEffectType => STATUS_EFFECT_TYPE.BURN;
    public override void UpdateEffect(GameObject target)
    {
        target.TryGetComponent<Health>(out var health);
        health.TakeDamage(damagePerSecond*Time.deltaTime);
    }
}


