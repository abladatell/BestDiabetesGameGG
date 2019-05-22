using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDespawner : MonoBehaviour
{

    public float expiryTime = 0f;
    // From time of creation, will despawn once expiry time has been reached.
    void Start()
    {
        Destroy(gameObject, expiryTime);
    }
}
