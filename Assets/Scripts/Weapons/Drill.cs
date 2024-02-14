using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : Weapon
{
    public Drill()
    {
        weaponType = WeaponType.Drill;
        WeaponName = "Drill";
        WeaponDamage = 25;
        Speed = 1.5f;
        // Note: Hits one enemy in front.
    }
}
