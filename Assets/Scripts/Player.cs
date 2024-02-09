using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    [SerializeField] private float maxEnergy = 100f;
    private float currentEnergy;

    [SerializeField] private float baseDamage = 10f;

    private UIManager uiManager;

    void Start()
    {
        // Find the UIManager in the scene
        uiManager = FindObjectOfType<UIManager>();

        currentHealth = maxHealth;

        if (uiManager == null)
        {
            Debug.LogError("UIManager not found in the scene. Make sure it's present and active.");
        }
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

            // UI management
            if (uiManager != null)
            {
                Debug.Log("Health UI updated");
                uiManager.UpdateHealthUI(currentHealth);
            }
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

            // UI management
            if (uiManager != null)
            {
                Debug.Log("Energy UI updated");
                uiManager.UpdateEnergyUI(currentEnergy);
            }
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