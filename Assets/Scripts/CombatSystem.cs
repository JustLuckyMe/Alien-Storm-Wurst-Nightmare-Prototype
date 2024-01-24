using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using StarterAssets;

public class CombatSystem : MonoBehaviour
{
    public ThirdPersonController Controller;

    private InputAction lightAttackAction;
    private bool isLightAttackOnCooldown = false;

    void Start()
    {
        // Create the "LightAttack" action in the new input system
        lightAttackAction = new InputAction(binding: "<Keyboard>/j");
        lightAttackAction.Enable();

        // Subscribe to the performed event only once
        lightAttackAction.performed += context => OnLightAttack();
    }

    void OnLightAttack()
    {
        // Check if the light attack is already on cooldown
        if (!isLightAttackOnCooldown)
        {
            Debug.Log("Player performed a light attack (pressed J)");

            // Trigger the light attack animation
            Controller.PerformLightAttack();

            // Set the cooldown flag to true
            isLightAttackOnCooldown = true;

            // Start the cooldown timer based on the animation length
            float animationLength = Controller.GetLightAttackAnimationLength();
            StartCoroutine(LightAttackCooldown(animationLength));
        }
        else
        {
            Debug.Log("Light attack is on cooldown");
        }
    }

    IEnumerator LightAttackCooldown(float cooldownDuration)
    {
        // Wait for the duration of the light attack animation
        yield return new WaitForSeconds(cooldownDuration);

        // Reset the cooldown flag after the cooldown duration
        isLightAttackOnCooldown = false;

        // Disable the light attack animation
        Controller.DisableLightAttackAnimation();
    }
}
