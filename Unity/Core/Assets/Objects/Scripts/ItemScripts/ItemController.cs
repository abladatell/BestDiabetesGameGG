using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public int healthChange = 0;
    private Collider col;
    public string name;

    // Gets the collider object
    void Start()
    {
        col = gameObject.GetComponent<Collider>();
    }

    // if the player's hitbox touches the item, send useItem command to player, alongside with which item is being used.
    void Update()
    {
        try
        {
            var cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("HitBox"));
            foreach (Collider c in cols)
            {
                if (c.name == "BodyCollider")
                {
                    c.SendMessageUpwards("useItem", this);
                    Destroy(gameObject, 0);
                }
                else
                {
                    continue;
                }
            }
        }catch(System.Exception e)
        {
            Debug.Log("Item Error: " + e);
        }
        
    }

    public string getName()
    {
        return name;
    }
}
