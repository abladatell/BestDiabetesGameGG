using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    //Boolean which checks paused.
    public bool paused;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;   
    }

    //Checks for pause, if not pause make it paused.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }
        if (paused)
        {
            Time.timeScale = 0;

        }
        else if (!paused)
            Time.timeScale = 1;
    }
}
