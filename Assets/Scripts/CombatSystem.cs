/*using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using StarterAssets;

public class CombatSystem : MonoBehaviour
{
    public Weapon weapon;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            // Delegate the attack to the current weapon
            if (Weapon.currentWeapon != null)
            {
                currentWeapon.Attack();
            }
        }
    }

    public void PerformLightAttack()
    {
        if (_hasAnimator)
        {
            _animator.SetTrigger(_animIDLightAttack);
        }
    }
}*/


/*    public ThirdPersonController Controller;
    public Weapon weapon;

    private InputAction lightAttackAction;
    private bool isLightAttackOnCooldown = false;

    public bool PlayerJustAttacked;

    void Start()
    {
        // Create the "LightAttack" action in the new input system
        lightAttackAction = new InputAction(binding: "<Keyboard>/j");
        lightAttackAction.Enable();

        // Subscribe to the performed event only once
        lightAttackAction.performed += context => weapon.Attack();
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
            PlayerJustAttacked = true;

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
        PlayerJustAttacked = false;
    }*/

