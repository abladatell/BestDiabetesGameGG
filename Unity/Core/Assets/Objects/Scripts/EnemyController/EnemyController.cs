using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // the player object which they target
    public GameObject player;
    // Animation controller
    Animator anime;
    // NavMeshAgent for navigating map
    private NavMeshAgent nav;
    // Max health of monster
    public int maxHealth = 3;
    // Current health of monster
    public int health;
    // The range where the monster will begin to chase / shoot
    public float aggroWidth = 10f;
    public float aggroHeight = 10f;
    // Weather the monster is ranged or not
    public bool isRanged = false;
    // If ranged, where they shoot
    public ProjectileSpawner gun;
    // Fire rate if they shoot
    public float fireRate = 0f;
    // Melee colliders if they do melee
    public Collider[] meleeHitBoxes;
    // Damage that they deal through ranged and melee
    public int damage = 1;
    private Transform playerPos;
    // Potential drops
    public GameObject[] drops;
    //Controls the audio file.
    public AudioSource audio;
    public float audioPlayTime = 1f;
    private float audioTimePlayed = 0f;

    // Gets nav mesh, sets health, gets animations
    void Start()
    {
        health = maxHealth;
        nav = GetComponent<NavMeshAgent>();
        anime = gameObject.GetComponent<Animator>();
        try
        {
            gun.GetComponent<ProjectileSpawner>().setDamage(damage);
        } catch (System.Exception e)
        {
            // Don't fill up the log for performance reasons.
        }
    }

    // Checks if player is in aggro range
    void FixedUpdate()
    {
        if(audioPlayTime <= audioTimePlayed)
        {
            audio.Stop();
            audioTimePlayed = 0f;
        }
        checkAggro();
        audioTimePlayed += Time.deltaTime;
    }

    // Triggered when monster takes damage. If killed, will drop a random item 40% of the time.
    public void takeDamage(int damage)
    {
        if(damage < 0)
        {
            damage = damage * -1;
        }
        health = health - damage;
        if (health <= 0)
        {
            anime.SetBool("die", true);
            Debug.Log("Enemy is dead");
            try
            { 
                if(Random.Range(0, 100) < 30)
                {
                    Quaternion pieceRotation = Quaternion.AngleAxis(270, Vector3.up);
                    GameObject go = (GameObject)Instantiate(
                    drops[Random.Range(0, drops.Length)], gameObject.transform.position, pieceRotation);
                }
            }
            catch (System.Exception)
            {
                Debug.Log("Drop failed");
            }
            Destroy(gameObject, 0);
        }
    }

    // Checks if player is in aggro range, and if so sets destination to go to to being the player and starts attacking.
    void checkAggro()
    {
        playerPos = player.transform;
        // Below checks if player is in aggro range
        if (playerPos.position.x > this.transform.position.x - aggroWidth && playerPos.position.x < this.transform.position.x + aggroWidth)
        {
            if (playerPos.position.z > this.transform.position.z - aggroHeight && playerPos.position.z < this.transform.position.z + aggroHeight)
            {
                // start chasing the player
                nav.SetDestination(player.transform.position);  
                // attacks the player
                if(audioTimePlayed == 0)
                {
                    audio.Play();
                }
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
            // sets shooting to false if ranged
            attack(false);
            // stops attack animation if it haves one.
            anime.SetBool("attack", false);
        }
    }

    // Called when attacking. If true then will start shooting if it haves a gun.
    void attack(bool rangedAttack)
    {
        try
        {
            
            if (rangedAttack) // Start shooting
            {
                anime.SetBool("attack", true);
                gun.setAggro(true);
                gun.setFireRate(fireRate);
                gun.setDamage(damage);
            }
            else if (isRanged) // Stop shooting
            {
                gun.setAggro(false);
                anime.SetBool("attack", false);
            }
            else // do a melee
            {
                anime.SetBool("attack", true);
                for(int i = 0; i < meleeHitBoxes.Length; i++)
                {
                    meleeAttack(meleeHitBoxes[i]);
                }
            }
        } catch (System.Exception e)
        {
            Debug.Log("Attack error: " + e);
        }
        
    }

    // Does a melee attack with this collider
    private void meleeAttack(Collider col)
    {
        try
        {
            var cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("HitBox"));
            foreach (Collider c in cols)
            {
                if (c.transform.parent.parent == transform) // Ignores own hitbox
                {
                    continue;
                }
                if(c.gameObject.name == "BodyCollider") // checks to make sure it is a player and not another monster.
                {
                    Debug.Log("Doing Damage");
                    c.SendMessageUpwards("takeDamage", damage);
                }
                
            }
        }
        catch (System.Exception e)
        {
            Debug.Log("melee Attack error: " + e);
        }
    }
}
