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
    public Animator animator; // Reference to the Animator component
    public ThirdPersonController Controller;

    [Header("Collider")]
    [SerializeField] private Collider weaponCollider; // Reference to the collider

    public bool IsAttacking { get; set; }
    private int comboCount = 0;
    public int maxComboCount = 2; // Set the maximum combo count

    private void Start()
    {
        SetColliderActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack();
        }
    }

    public void Attack()
    {
        // Check if the attack animation is already playing
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Mutant Punch"))
        {
            // Animation is still playing, don't start a new one
            return;
        }

        comboCount++;

        // Check if the combo count exceeds the maximum allowed
        if (comboCount > maxComboCount)
        {
            comboCount = 1; // Reset the combo count if it exceeds the maximum
        }

        // Trigger the appropriate attack animation based on the combo count
        if (animator != null)
        {
            animator.SetInteger("ComboCount", comboCount);
            animator.SetTrigger("LightAttack");
        }

        StartCoroutine(PlayAttackAnimation());
        SetColliderActive(true);

        // Implement any other weapon-specific logic here
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(enemyTag))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            Debug.Log("Touched an enemy");
            enemy.ReceiveDamage(WeaponDamage);
        }
    }

    public void SetColliderActive(bool active)
    {
        if (weaponCollider != null)
        {
            weaponCollider.enabled = active;
            //Debug.Log($"Collider is now {(active ? "active" : "inactive")}");
        }
        else
        {
            //Debug.Log("Collider reference not set in the Inspector");
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

            //Debug.Log($"{WeaponName} is attacking!");
            yield return new WaitForSeconds(5);
            SetColliderActive(false);
            IsAttacking = false;
        }
    }
}
