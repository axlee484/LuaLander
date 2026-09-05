using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField] private float damage = 0f;
    public float Damage => damage;
    [SerializeReference] private BaseStatusEffect[] statusEffects;
    public IReadOnlyList<BaseStatusEffect> StatusEffects => statusEffects;

}
