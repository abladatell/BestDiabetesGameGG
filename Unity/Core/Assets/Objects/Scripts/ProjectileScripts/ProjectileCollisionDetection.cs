using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollisionDetection : MonoBehaviour
{
    public GameObject bullet;
    public Collider bulletCollider;
    public int damage = 0;
    public GameObject playerCollider;

    // Fixed Update
    void FixedUpdate()
    {
        // Checks to see if anything is colliding with the collider.
        var col = bulletCollider;
        var cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("HitBox"));
        // If there is a collider, determins if it takes damage or if the projectile needs to despawn.
        foreach (Collider c in cols)
        {
            try
            {
                // if the collision is from the thing that spawned the projectile, pass through it.
                if (c.transform.parent.parent.name == playerCollider.name)
                {
                    continue;
                }
                //sends damage to the owner of the collid4
                    c.SendMessageUpwards("takeDamage", damage);
                    Destroy(gameObject, 0.05f);
            } catch (System.Exception e)
            {
                // If an error occures, get rid of the projectile.
                Destroy(gameObject, 0.05f);
            }
            
        }
    }

    // Sets damage
    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }
}