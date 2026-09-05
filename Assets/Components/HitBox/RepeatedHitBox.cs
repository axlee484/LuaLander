using System.Collections.Generic;
using UnityEngine;

public class RepeatedHitBox : HitBox
{
    [SerializeField] private float damagePerSecond = 10f;
    public float DamagePerSecond => damagePerSecond;

}
