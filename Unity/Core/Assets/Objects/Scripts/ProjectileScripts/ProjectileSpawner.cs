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
        rbody = GetComponent<Rigidbody>();
        bulletSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");


        rbody.velocity = new Vector3(h, v, 0);

        if (isPlayer && (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))) {
            Target();
            Shoot();
        }

        if (isAggro)
        {
            Shoot();
        }

        timeElapsed += Time.deltaTime;
    }

    void Target()
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

    void Shoot()
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

    public void setAggro(bool aggro)
    {
        isAggro = aggro;
    }

    public void setFireRate(float newFireRate)
    {
        shootRate = newFireRate;
    }

    public void setDamage(int newDamage)
    {
        damage = newDamage;
    }
}
