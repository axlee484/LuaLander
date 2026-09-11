using UnityEngine;

public class HealthBar : ProgressBar
{
    [SerializeField] private Health health;
    public override float MaxValue => health.MaxHealth;
    public override float Value => health.CurrentHealth;
}
