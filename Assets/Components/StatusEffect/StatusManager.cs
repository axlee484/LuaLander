using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum STATUS_EFFECT_TYPE
{
    NONE,
    BURN,
    FREEZE,
    PARALYZE
}

public class StatusManager : MonoBehaviour
{
    [SerializeField] private STATUS_EFFECT_TYPE[] immuneStatusEffects;
    private readonly List<BaseStatusEffect> activeStatusEffects = new();
    public void ApplyStatusEffect(BaseStatusEffect statusEffect)
    {
        if(immuneStatusEffects.Contains(statusEffect.StatusEffectType)) return;
        
        activeStatusEffects.Add(statusEffect);
        statusEffect.ApplyEffect(gameObject);
        statusEffect.OnRemoved += RemoveStatusEffect;
        StartCoroutine(statusEffect.StatusEffectCoroutine());
    }
    void Update()
    {
        activeStatusEffects.ForEach(statusEffect =>
        {
            statusEffect.UpdateEffect(gameObject);
        });
    }

    void RemoveStatusEffect(BaseStatusEffect statusEffect)
    {
        statusEffect.RemoveEffect(gameObject);
        statusEffect.OnRemoved -= RemoveStatusEffect;
        activeStatusEffects.Remove(statusEffect);
    }


}
