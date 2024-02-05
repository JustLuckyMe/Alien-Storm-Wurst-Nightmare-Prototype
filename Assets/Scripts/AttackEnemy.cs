using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    CombatSystem combatSystem;
    void Update()
    {
        void OnTriggerEnter(Collider collision)
        {
            if (collision.CompareTag("Enemy"))
            {
                Debug.Log("Enemy is in range");

                if (combatSystem.PlayerJustAttacked)

                {
                    Debug.Log("Player just attacked and enemy is in range, enemy loses health");

                }
            }
        }
    }
}
