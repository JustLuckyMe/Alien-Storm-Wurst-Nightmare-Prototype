/*using System.Collections;
using UnityEngine;
using StarterAssets;

public class WeaponFirst : MonoBehaviour
{
    [Header("Weapon")]
    public string weaponType;
    public string WeaponName;
    public int WeaponDamage;
    public float Speed;

    public string enemyTag = "Enemy";

    [Header("Animation")]
    public ThirdPersonController Controller;

    [Header("Collider")]
    [SerializeField] private Collider weaponCollider; // Reference to the collider

    public bool IsAttacking { get; set; }

    public void SetColliderActive(bool active)
    {
        if (weaponCollider != null)
        {
            weaponCollider.enabled = active;
            Debug.Log($"Collider is now {(active ? "active" : "inactive")}");
        }
        else
        {
            Debug.Log("Collider reference not set in the Inspector");
        }
    }

    private void Start()
    {
        SetColliderActive(false);
    }

    public void Attack()
    {
        StartCoroutine(PlayAttackAnimation());
        SetColliderActive(true);
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
                //Debug.Log($"Controller found: {Controller.name}");
                Controller.PerformLightAttack();
            }
            else
            {
                Debug.Log("No controller found");
            }

            Debug.Log($"{WeaponName} is attacking!");
            yield return new WaitForSeconds(5);
            SetColliderActive(false);
            IsAttacking = false;
        }
    }
}
*/