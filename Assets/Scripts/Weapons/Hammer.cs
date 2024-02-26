/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : Weapon
{
    void Start()
    {
        weaponType = "Hammer";
        WeaponName = "Hammer";
        WeaponDamage = 50;
        Speed = 0.5f;
        // Note: Can hit multiple enemies in front.
    }

    public override IEnumerator PlayAttackAnimation()
    {
        if (!IsAttacking)
        {
            IsAttacking = true;

            if (Controller != null)
            {
                Debug.Log($"Controller found: {Controller.name}");
                Controller.PerformHammerAttack();
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