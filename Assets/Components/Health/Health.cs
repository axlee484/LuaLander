using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    public void Awake()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        print("Health: "+currentHealth);
        if (currentHealth <= 0)
        {
            // Handle death logic here
            Debug.Log($"{gameObject.name} has died.");
        }
    }
}
