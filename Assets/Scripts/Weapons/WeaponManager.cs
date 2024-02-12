using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public WeaponType currentWeaponType;
    private GameObject currentWeapon;

    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private GameObject SwordPrefab;
    [SerializeField] private GameObject AxePrefab;
    [SerializeField] private GameObject BowPrefab;

    private void Start()
    {
        // Initialize with a default weapon
        SwitchWeapon(WeaponType.Sword);
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
        if (Input.GetMouseButtonDown(0))
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
    }

    private void ActivateWeapon(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.Sword:
                SwordPrefab.SetActive(true);
                currentWeapon = SwordPrefab;
                break;
            case WeaponType.Axe:
                AxePrefab.SetActive(true);
                currentWeapon = AxePrefab;
                break;
            case WeaponType.Bow:
                BowPrefab.SetActive(true);
                currentWeapon = BowPrefab;
                break;
            default:
                break;
        }

        // Update the currentWeaponType
        currentWeaponType = weaponType;
    }

    private void DeactivateAllWeapons()
    {
        // Deactivate all weapons
        SwordPrefab.SetActive(false);
        AxePrefab.SetActive(false);
        BowPrefab.SetActive(false);
    }

    private void Attack()
    {
        Debug.Log("Player attacked with weapon: " + currentWeaponType);
    }
}
