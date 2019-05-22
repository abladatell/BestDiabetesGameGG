using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userNameRememberer : MonoBehaviour
{

    public string userName;
    // This makes it so it doesn't destroy itself.
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    
    
}
