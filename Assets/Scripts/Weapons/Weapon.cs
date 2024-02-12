using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Sword,
    Axe,
    Bow,
    // Add more weapon types as needed
}

public class Weapon : MonoBehaviour
{
    public WeaponType weaponType;

    public virtual void Attack()
    {
        // Base implementation for attacking
        Debug.Log($"Attacking with {weaponType}");
    }
}

public class Sword : Weapon
{
    // Additional properties or methods specific to the Sword
}

public class Axe : Weapon
{
    // Additional properties or methods specific to the Axe
}

public class Bow : Weapon
{
    // Additional properties or methods specific to the Bow
}