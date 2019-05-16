using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    Animator anime;
    private NavMeshAgent nav;
    public int maxHealth = 3;
    public int health;
    public float aggroWidth = 10f;
    public float aggroHeight = 10f;
    public bool isRanged = false;
    public ProjectileSpawner gun;
    public float fireRate = 0f;
    public Collider[] meleeHitBoxes;
    public int damage = 1;
    private Transform playerPos;


    void Start()
    {
        health = maxHealth;
        nav = GetComponent<NavMeshAgent>();
        anime = gameObject.GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        checkAggro();
    }

    public void takeDamage(int damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            Debug.Log("Enemy is dead");
            Destroy(gameObject, 0);
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
                
                nav.SetDestination(player.transform.position);
                
                if (isRanged)
                {
                    attack(true); 
                }
                else
                {
                    attack(false);
                }
            }
        }
        else
        {
            attack(false);
        }
    }

    void attack(bool rangedAttack)
    {
        if (rangedAttack)
        {
            gun.setAggro(true);
            gun.setFireRate(fireRate);
            gun.setDamage(damage);
        }
        else if(isRanged)
        {
            gun.setAggro(false);
        } else
        {
            meleeAttack(meleeHitBoxes[0]);
        }
    }

    private void meleeAttack(Collider col)
    {
        try
        {
            var cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("HitBox"));
            foreach (Collider c in cols)
            {
                if (c.transform.parent.parent == transform)
                {
                    continue;
                }
                c.SendMessageUpwards("takeDamage", damage);
                Debug.Log("Doing Damage");
            }
        }
        catch (System.Exception e)
        {
            //NOTHING
        }
    }
}
