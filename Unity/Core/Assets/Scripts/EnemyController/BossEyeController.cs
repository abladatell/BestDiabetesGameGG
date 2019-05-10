using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEyeController : MonoBehaviour
{
    public int maxHealth = 300;
    public int health;
    public float aggroWidth = 10f;
    public float aggroHeight = 10f;
    private Transform playerPos;
    public float moveSpeed = 1f;

    public int stageTransitionOne = 200;
    public int stageTransitionTwo = 100;
    public float attackTransitionTime = 1f;

    void Start()
    {
        health = maxHealth;
    }


    void FixedUpdate()
    {
        checkAggro();
        if (health <= 0)
        {
            Destroy(gameObject, 0);
        }
    }

    public void takeDamage(int damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            Debug.Log("Eye Boss is dead");
        }
    }

    void checkAggro()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        // Below checks if player is in aggro range
        if (playerPos.position.x > this.transform.position.x - aggroWidth && playerPos.position.x < this.transform.position.x + aggroWidth)
        {
            if (playerPos.position.z > this.transform.position.z - aggroHeight && playerPos.position.z < this.transform.position.z + aggroHeight)
            {
                meleeAggro(playerPos);
            }
        }
    }

    void meleeAggro(Transform target)
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, target.position, moveSpeed * Time.deltaTime);
        this.transform.LookAt(target);
    }
}
