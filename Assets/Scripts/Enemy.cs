using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyHealth;
    public int enemyAttack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AttackPlayer()
    {
        Debug.Log("Enemy attacked Player");
    }

    public void RecieveDamage(int playerDamage)
    {
        Debug.Log($"Recieved" + playerDamage + "from player");
        enemyHealth -= playerDamage;
        Debug.Log($"Enemy Health is now" + enemyHealth);
    }
}
