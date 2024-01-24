using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Health = 100;
    public float Sprint = 100;

    public int attackDamage;
    

    public Enemy enemy;

    void Awake()
    {
        
    }

    void Update()
    {
        
    }

    public void takeDamage()
    {
        Health -= enemy.enemyAttack;
    }
}
