using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] public int maxHealth = 10;
    [SerializeField] public int currentHealth;

    [SerializeField] private int maxEnergy = 100;
    [SerializeField] private int currentEnergy;

    [SerializeField] private int baseDamage = 1;

    private UIManager uiManager;

    void Start()
    {
        currentHealth = maxHealth;
/*        // Find the UIManager in the scene
        uiManager = FindObjectOfType<UIManager>();


        if (uiManager == null)
        {
            Debug.LogError("UIManager not found in the scene. Make sure it's present and active.");
        }*/
    }

    void Update()
    {
        /*if (uiManager != null)
        {
            uiManager.UpdateHearts(currentHealth);
        }*/
    }


    // Player movement (animation will be separate just for convenience)
    void Move() { }

    void Block() { }

    void Jump() { }


    public void TakeDamage(int enemyDmg)
    {
        if (currentHealth > 0)
        {
            currentHealth -= enemyDmg;

            if (currentHealth <= 0)
            {
                PlayerDeath();
            }
        }

        // Call to update hearts when health changes
        //uiManager.UpdateHearts(currentHealth);
    }


    public void GainHealth(int healthAmount)
    {
        Debug.Log("Player picked up a health pack!");

        if (currentHealth < maxHealth)
        {
            currentHealth += healthAmount;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

            // Call to update hearts when health changes
            //uiManager.UpdateHearts(currentHealth);
        }
        else
        {
            Debug.Log("Player already has max health, health doesn't change");
        }
    }

    public void GainEnergy(int energyAmount)
    {
        Debug.Log("Player gained energy!");

        if (currentEnergy < maxEnergy)
        {
            currentEnergy += energyAmount;
            currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);
        }
        else
        {
            Debug.Log("Player already has max energy");
        }
    }

    void PlayerDeath()
    {
        Debug.Log("Player is fucking dead bro");
        // Play death animation
        // Play game over screen
    }
}