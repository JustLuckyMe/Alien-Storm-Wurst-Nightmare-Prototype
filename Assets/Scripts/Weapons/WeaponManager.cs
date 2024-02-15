using System.Collections.Generic;
using UnityEngine;
using StarterAssets;


public class WeaponManager : MonoBehaviour
{
    private GameObject currentWeapon;

    [Header("Quick Access:")]
    [SerializeField] private Transform spawnpoint;

    [Header("Weapons:")]
    [SerializeField] private GameObject DrillPrefab;
    [SerializeField] private GameObject HammerPrefab;
    [SerializeField] private GameObject GunPrefab;

    private enum WeaponType
    {
        Drill,
        Hammer,
        Gun
    }

    private WeaponType currentWeaponType;

    private void Start()
    {
        // Initialize with a default weapon
        SwitchWeapon(WeaponType.Drill);
    }

    private void Update()
    {
        // Check for a key press to switch weapons
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchToNextWeapon();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchToPreviousWeapon();
        }

        // Check for a key press to attack
        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack();
        }
    }

    private void SwitchToNextWeapon()
    {
        int nextIndex = ((int)currentWeaponType + 1) % System.Enum.GetValues(typeof(WeaponType)).Length;
        SwitchWeapon((WeaponType)nextIndex);
    }

    private void SwitchToPreviousWeapon()
    {
        int previousIndex = (int)currentWeaponType - 1;
        if (previousIndex < 0)
        {
            previousIndex = System.Enum.GetValues(typeof(WeaponType)).Length - 1;
        }

        SwitchWeapon((WeaponType)previousIndex);
    }

    private void SwitchWeapon(WeaponType newWeaponType)
    {
        // Deactivate all weapons before switching
        DeactivateAllWeapons();

        // Activate the new weapon
        ActivateWeapon(newWeaponType);

        // Ensure currentWeapon is not null after activation
        if (currentWeapon != null)
        {
            // Update the currentWeaponType
            currentWeaponType = newWeaponType;
        }
        else
        {
            Debug.LogError("currentWeapon is null after activation!");
        }
    }

    private void ActivateWeapon(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.Drill:
                DrillPrefab.SetActive(true);
                currentWeapon = DrillPrefab;
                break;
            case WeaponType.Hammer:
                HammerPrefab.SetActive(true);
                currentWeapon = HammerPrefab;
                break;
            case WeaponType.Gun:
                GunPrefab.SetActive(true);
                currentWeapon = GunPrefab;
                break;
            default:
                break;
        }

        // Update the currentWeaponType
        currentWeaponType = weaponType;
        Debug.Log("Current Weapon: " + currentWeapon);
    }

    private void DeactivateAllWeapons()
    {
        // Deactivate all weapons
        DrillPrefab.SetActive(false);
        HammerPrefab.SetActive(false);
        GunPrefab.SetActive(false);
    }

    private void Attack()
    {
        // Check if the current weapon is valid
        if (currentWeapon != null)
        {
            currentWeapon.GetComponent<Weapon>().Attack();
        }
    }

}
