using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 3;
    public int health;



    void Start()
    {
        health = maxHealth;
    }

    
    void Update()
    {

    }

    public void takeDamage(int damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            Debug.Log("Enemy is dead");
        }
    }
}
