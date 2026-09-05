using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeReference] private BaseStatusEffect[] statusEffects;
    public IReadOnlyList<BaseStatusEffect> StatusEffects => statusEffects;

}
