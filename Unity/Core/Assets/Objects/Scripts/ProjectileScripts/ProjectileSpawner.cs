using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{

    public float moveForce = 0f;
    private Rigidbody rbody;
    public GameObject bullet;
    public Transform gun;
    public int damage = 1;
    public float shootRate = 0f;
    public float shootForce = 0f;
    private float timeElapsed = 0f;
    public bool isPlayer = false;
    public bool isAggro = false;
    private Vector3 lookPos;
    private AudioSource bulletSound; 

    // Start is called before the first frame update
    void Start()
    {
        // Grabbing componenets for later use.
        rbody = GetComponent<Rigidbody>();
        bulletSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Player inputs
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");


        rbody.velocity = new Vector3(h, v, 0);

        // If it is the player then it needs to be activated. Will target and shoot to where the mouse is.

#if UNITY_STANDALONE_WIN || UNITY_WEBGL

        if (isPlayer && (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))) {
            Target();
            Shoot();
        }
#endif
        // If the AI is triggered it will shoot straight forward.
        if (isAggro)
        {
            Shoot();
        }

        // Time between shots
        timeElapsed += Time.deltaTime;
    }

    // Targets to where the mouse position is in the gameworld.
    public void Target()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            lookPos = hit.point;
        }

        Vector3 lookDir = lookPos - transform.position;
        lookDir.y = 0;

        transform.LookAt(transform.position + lookDir, Vector3.up);
    }

    // Shoots a projectile at the determined firerate.
    public void Shoot()
    {
        if (timeElapsed > shootRate)
        {
            
            try
            {
                GameObject go = (GameObject)Instantiate(
                bullet, gun.position, gun.rotation);
                go.GetComponent<Rigidbody>().AddForce(gun.forward * shootForce);
                bulletSound.Play();
                go.GetComponent<ProjectileCollisionDetection>().SetDamage(damage);
            }catch (System.Exception e)
            {
            }
            finally
            {
                timeElapsed = 0;
            }
        }
    }

    // For AI to shoot this needs to be called true
    public void setAggro(bool aggro)
    {
        isAggro = aggro;
    }

    // Allows for changing the fire rate of a projectile spawner.
    public void setFireRate(float newFireRate)
    {
        shootRate = newFireRate;
    }

    // Sets the damage of the projectiles spawned.
    public void setDamage(int newDamage)
    {
        damage = newDamage;
    }
}
