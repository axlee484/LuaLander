using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class HurtBox : MonoBehaviour
{
    private Health health;
    private StatusManager statusManager;
    private readonly HashSet<Collision2D> repeatedHitBoxCollisions = new();

    void Awake()
    {
        health = GetComponent<Health>();
        statusManager = GetComponent<StatusManager>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.TryGetComponent<HitBox>(out var hitBox);
        if (hitBox == null) return;
        var statusEffects = hitBox.StatusEffects;
        foreach(var statusEffect in statusEffects)
        {
            statusManager.ApplyStatusEffect(statusEffect);
        }
        if(hitBox is RepeatedHitBox) repeatedHitBoxCollisions.Add(collision);

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<RepeatedHitBox>(out var repeatedHitBox))
        {
            repeatedHitBoxCollisions.Remove(collision);
        }
    }

    private void ApplyRepeatedHitBoxDamage(Collision2D collision)
    {
        collision.gameObject.TryGetComponent<RepeatedHitBox>(out var repeatedHitBox);
        if (repeatedHitBox == null) return;
        health.TakeDamage(repeatedHitBox.DamagePerSecond*Time.fixedDeltaTime);
        
    }

    void FixedUpdate()
    {
        repeatedHitBoxCollisions.ToList().ForEach(collision => ApplyRepeatedHitBoxDamage(collision));
    }
}
