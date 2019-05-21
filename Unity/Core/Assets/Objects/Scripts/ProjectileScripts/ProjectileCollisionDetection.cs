using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollisionDetection : MonoBehaviour
{
    public GameObject bullet;
    public Collider bulletCollider;
    public int damage = 0;
    public GameObject playerCollider;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Fixed Update
    void FixedUpdate()
    {
        var col = bulletCollider;
        var cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("HitBox"));
        foreach (Collider c in cols)
        {
            try
            {
                if (c.transform.parent.parent.name == playerCollider.name)
                {
                    continue;
                }
                if (c.transform.parent.parent == transform)
                {
                    Destroy(gameObject, 0);
                }
                c.SendMessageUpwards("takeDamage", damage);
                Destroy(gameObject, 0);
            } catch (System.Exception e)
            {
                Destroy(gameObject, 0);
            }
            
        }
    }

    // Sets damage
    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }
}