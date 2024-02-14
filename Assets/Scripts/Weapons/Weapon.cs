using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Drill,
    Hammer,
    Gun, //maybe laser?
}

public class Weapon : MonoBehaviour
{
    public WeaponType weaponType;
    public string WeaponName;
    public int WeaponDamage;
    public float Speed;

    // Add references to attack animations
    public AnimationClip drillAttackAnimation;
    public AnimationClip hammerAttackAnimation;
    public AnimationClip gunAttackAnimation;

    public virtual void Attack()
    {
        // Play the corresponding attack animation based on weapon type
        switch (weaponType)
        {
            case WeaponType.Drill:
                StartCoroutine(PlayAnimation(drillAttackAnimation));
                break;
            case WeaponType.Hammer:
                StartCoroutine(PlayAnimation(hammerAttackAnimation));
                break;
            case WeaponType.Gun:
                StartCoroutine(PlayAnimation(gunAttackAnimation));
                break;
            default:
                break;
        }

        // Base implementation for attacking
        Debug.Log($"Attacking with {WeaponName}");
    }

    private IEnumerator PlayAnimation(AnimationClip animationClip)
    {
        // Play the attack animation
        // You may need to adjust this based on your animation system
        yield return new WaitForSeconds(0.1f);  // Adjust the delay based on your animation length
        // Play the actual animation here
    }
}

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

public class Hammer : Weapon
{
    public Hammer()
    {
        weaponType = WeaponType.Hammer;
        WeaponName = "Hammer";
        WeaponDamage = 50;
        Speed = 0.5f; 
        // Note: Can hit multiple enemies in front.
    }
}

public class Gun : Weapon
{
    public Gun()
    {
        weaponType = WeaponType.Gun;
        WeaponName = "Pew Pew";
        WeaponDamage = 35;
        Speed = 2f; 
        // Note: Ranged attack. Can hit the first enemy in front.
    }
}
