using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<Weapon> unlockedWeapons = new List<Weapon>();
    private int currentWeaponIndex = 0;

    // Method to switch to the next weapon
    public void SwitchToNextWeapon()
    {
        if (unlockedWeapons.Count == 0)
        {
            Debug.LogWarning("No unlocked weapons available.");
            return;
        }

        // Increment the current weapon index
        currentWeaponIndex = (currentWeaponIndex + 1) % unlockedWeapons.Count;

        // Call a method to handle switching the actual weapon in the game
        SwitchWeaponInGame();
    }

    // Method to switch the actual weapon in the game
    private void SwitchWeaponInGame()
    {
        // Logic to deactivate the current weapon and activate the new one
        // You may need to handle weapon swapping logic based on your game's requirements
        // For example, deactivating the current weapon's GameObject and activating the new one.
        // You can also update UI to show the current weapon.
        Debug.Log("Switching to weapon: " + unlockedWeapons[currentWeaponIndex].WeaponName);
    }
}
