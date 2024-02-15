using System.Collections;
using UnityEngine;
using StarterAssets;


public class Weapon : MonoBehaviour
{
    [Header("Weapon")]
    public string weaponType;
    public string WeaponName;
    public int WeaponDamage;
    public float Speed;

    public string enemyTag = "Enemy";

    [Header("Animation")]
    public ThirdPersonController Controller;

    public bool IsAttacking { get; set; }

    public virtual void Attack()
    {
        StartCoroutine(PlayAttackAnimation());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(enemyTag))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            Debug.Log("Touched an enemy");
            enemy.RecieveDamage(WeaponDamage);
        }
    }

    public virtual IEnumerator PlayAttackAnimation()
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
