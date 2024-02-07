using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth = 100f;
    [SerializeField] private float maxEnergy = 100f;
    [SerializeField] private float currentEnergy = 0f;
    [SerializeField] private float baseDamage = 10f;

    void Awake()
    {
        // Enemy enemy = GetComponent<Enemy>();
    }

    // Player movement (animation will be separate just for convenience)
    void Move() { }

    void Block() { }

    void Jump() { }

    public void TakeDamage(float enemyDmg)
    {
        if (currentHealth > 0)
        {
            currentHealth -= enemyDmg;

            if (currentHealth <= 0)
            {
                PlayerDeath();
            }
        }
    }

    public void GainHealth(float healthAmount)
    {
        Debug.Log("Player picked up a health pack!");

        if (currentHealth < maxHealth)
        {
            currentHealth += healthAmount;
            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        }
        else
        {
            Debug.Log("Player already has max health, health doesn't change");
        }
    }

    public void GainEnergy(float energyAmount)
    {
        Debug.Log("Player gained energy!");

        if (currentEnergy < maxEnergy)
        {
            currentEnergy += energyAmount;
            currentEnergy = Mathf.Clamp(currentEnergy, 0f, maxEnergy);
        }
        else
        {
            Debug.Log("Player already has max energy");
        }
    }

    void PlayerDeath()
    {
        // Play death animation
        // Play game over screen
    }

}