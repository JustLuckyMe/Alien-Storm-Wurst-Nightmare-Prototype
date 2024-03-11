using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public int enemyHealth = 100; // Health points for the enemy, assuming it might be used later
    [SerializeField] Collider enemyCollider; // reference to the collider

    [Header("Enemy Attack")]
    [SerializeField] protected float attackRange = 1.5f; // Range within which the enemy can attack the player
    [SerializeField] protected int attackDamage = 1;
    [SerializeField] float cooldown = 4f;
    bool IsAttacking = false;

    [Header("Enemy Animation")]
    public EnemyController Controller;


    [Header("Enemy Pathing")]
    public Transform target; // The player
    [SerializeField] protected float patrolSpeed = 2.0f;
    [SerializeField] protected float detectionRange = 5f;
    [SerializeField] protected float stopDistance = 0.5f;
    [SerializeField] protected Transform[] patrolPoints;


    private int currentPatrolIndex = 0;
    private bool isAttacking = false;

    private void Update()
    {
        DetectAndAct();
    }

    protected virtual void DetectAndAct()
    {
        if (target == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        if (IsEnemyHit())
        {
            MoveTowardsPlayer();
        }
        else if (distanceToPlayer <= detectionRange)
        {
            if (distanceToPlayer <= attackRange && !isAttacking)
            {
                PlayAttackAnimation();
            }
            else
            {
                MoveTowardsPlayer();
            }
        }
        else
        {
            Patrol();
        }
    }

    protected virtual void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        Transform targetPoint = patrolPoints[currentPatrolIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, patrolSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }

    protected virtual void MoveTowardsPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        if (distanceToPlayer > stopDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, patrolSpeed * Time.deltaTime);
            
        }
    }

    public void ReceiveDamage(int WeaponDamage)
    {
        if (enemyHealth > 0)
        {
            enemyHealth -= WeaponDamage;

            if (enemyHealth <= 0)
            {
                EnemyDeath();
            }
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
                Controller.AttackPlayerAnim();
            }
            else
            {
                Debug.Log("No controller found");
            }

            Debug.Log("Enemy is attacking!");
            yield return new WaitForSeconds(cooldown);
            SetColliderActive(false); //need to set a collider that will attack the player
            IsAttacking = false;
        }
    }

    public void SetColliderActive(bool active)
    {
        if (enemyCollider != null)
        {
            enemyCollider.enabled = active;
            Debug.Log($"Collider is now {(active ? "active" : "inactive")}");
        }
        else
        {
            Debug.Log("Collider reference not set in the Inspector");
        }
    }

    void EnemyDeath()
    {
        //Play Death animaion here idk bro
        Debug.Log("Enemy is fucking dead bro");
        this.gameObject.SetActive(false);
    }

    protected virtual bool IsEnemyHit()
    {
        return enemyHealth < 100; // Adjust the threshold as needed
    }

}