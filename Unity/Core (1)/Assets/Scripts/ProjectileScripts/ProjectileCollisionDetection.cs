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

    // Update is called once per frame
    void Update()
    {
        var col = bulletCollider;
        var cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("HitBox"));
        foreach (Collider c in cols)
        {
            if (c.name == "BodyCollider")
            {
                continue;
            }
            if (c.transform.parent.parent == transform)
            {
                Destroy(gameObject, 0);
            }
            c.SendMessageUpwards("takeDamage", damage);
            Destroy(gameObject, 0);
        }
    }
}