using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditScript : MonoBehaviour
{
    public Image image;
    public BossEyeController eyeController;
    Animator anim;
    AudioSource audioSource;

    private void Start()
    {
        //Instantiate Animator from the GameObject
        anim = GetComponent<Animator>();
        //Instantiate AudioSource from the GameObject
        audioSource = GetComponent<AudioSource>();
        
    }

    //Runs the script when the animation is finished and sends to the front screen.
    public void AlertObservers(int num)
    {
        if (num==1)
        {
            Debug.Log("Animation Finished");
            //Sends to Scene
            SceneManager.LoadScene("Anadi is actually really nice UI", LoadSceneMode.Single);
            
        }
    }
}
