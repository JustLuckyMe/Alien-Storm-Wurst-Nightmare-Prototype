using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public WeaponType currentWeaponType;
    private GameObject currentWeapon;

    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private GameObject DrillPrefab;
    [SerializeField] private GameObject HammerPrefab;
    [SerializeField] private GameObject GunPrefab;

    // bools for each weapon attack
    private bool isDrillAttacking = false;
    private bool isHammerAttacking = false;
    private bool isGunAttacking = false;

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
        Debug.Log("Player attacked with weapon: " + currentWeaponType);


    }
}
