using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("Boss Attributes")]
    public int bossHealth = 1000;
    public int bossDamage = 50;
    public float speed = 0.2f;

    // Enemy Pathing
    private Transform playerTransform;

    // Phase Control
    private bool isPhaseTwo = false;

    [Header("Attack Mechanisms")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private float attackCooldown = 2f;
    private float lastAttackTime = -2f; 

    void Start()
    {
        // Find the player in the scene and set up tracking
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Exit early if the boss is defeated
        if (bossHealth <= 0) return;

        // Determine the current phase and execute the corresponding attack pattern
        if (!isPhaseTwo)
        {
            // Phase 1 Logic
            PhaseOneBehavior();
        }
        else
        {
            // Phase 2 Logic
            PhaseTwoBehavior();
        }

        // Switch to phase 2 when health is at or below half, enhancing boss capabilities
        if (bossHealth <= 500 && !isPhaseTwo)
        {
            TransitionToPhaseTwo();
        }

        // Continuously track and move towards the player
        TrackPlayer();
    }

    void TrackPlayer()
    {
        // Move the boss towards the player's current position
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
    }

    void PhaseOneBehavior()
    {
        // Execute phase 1 attack pattern if cooldown has elapsed
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            AttackPatternPhase1();
            lastAttackTime = Time.time; // Reset the attack timer
        }
    }

    void PhaseTwoBehavior()
    {
        // Execute phase 2 attack pattern if cooldown has elapsed
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            AttackPatternPhase2();
            lastAttackTime = Time.time; // Reset the attack timer
        }
    }

    void AttackPatternPhase1()
    {
        // Example phase 1 attack: shooting a projectile towards the player
        if (projectilePrefab && projectileSpawnPoint)
        {
            Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.LookRotation(playerTransform.position - projectileSpawnPoint.position));
        }
    }

    void AttackPatternPhase2()
    {
        // Example phase 2 attack: reusing phase 1 logic for simplicity, but can be customized
        AttackPatternPhase1();
        // Customize further for more challenging phase 2 attacks
    }
    void TransitionToPhaseTwo()
    {
        isPhaseTwo = true;
        speed *= 1.5f; // Increase movement speed
        attackCooldown /= 2; // Increase attack frequency
    }

    public void ReceiveDamage(int weaponDamage)
    {
        bossHealth -= weaponDamage;

        if (bossHealth <= 0)
        {
            BossDeath();
        }
    }

    void BossDeath()
    {
        Debug.Log("Boss Defeated!");
        // Handle boss defeat (animations, cleanup, etc.)
        gameObject.SetActive(false);
    }
}
