using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{

    public bool isPlayer = false;
    public float gunRotation = 0f;
    public Transform gun;
    private Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotates the gunobject around the player
        if (isPlayer && (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Space)))
        {
            float xPos = Input.mousePosition.x;
            float zPos = Input.mousePosition.y;
            Vector3 mouseLocation = new Vector3(xPos, 0, zPos);
            gun.LookAt(mouseLocation);
        }
    }
}
