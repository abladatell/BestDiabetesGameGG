using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontScreenBGAudioScript : MonoBehaviour
{

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate audioSource from GameObject
        audioSource = GetComponent<AudioSource>();
        audioSource.time = 2.5f;   // Sets 
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
