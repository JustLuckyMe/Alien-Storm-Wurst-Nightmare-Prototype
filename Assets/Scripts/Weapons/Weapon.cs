using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private string weaponName;
    [SerializeField] private float weaponDamage;

    public string WeaponName => weaponName;
    public float WeaponDamage => weaponDamage;

    public void Attack()
    {
        Debug.Log("Player hit enemy");
    }
}
