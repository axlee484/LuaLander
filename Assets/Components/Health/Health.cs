using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    public float MaxHealth => maxHealth;
    private float currentHealth;
    public float CurrentHealth => currentHealth;

    public void Awake()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            // Handle death logic here
            print($"{gameObject.name} has died.");
        }
    }
}
