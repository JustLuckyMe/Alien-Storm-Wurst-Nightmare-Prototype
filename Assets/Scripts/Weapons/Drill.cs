/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : Weapon
{

    void Start()
    {
        weaponType = "Drill";
        WeaponName = "Drill";
        WeaponDamage = 25;
        Speed = 1.5f;
        IsAttacking = false;
    }

    public override IEnumerator PlayAttackAnimation()
    {
        if (!IsAttacking)
        {
            IsAttacking = true;

            if (Controller != null)
            {
                Debug.Log($"Controller found: {Controller.name}");
                Controller.PerformLightAttack();
            }
            else
            {
                Debug.Log("No controller found");
            }


            Debug.Log($"{WeaponName} is attacking!");
            yield return new WaitForSeconds(Speed);

            IsAttacking = false;
        }
    }
}
*/