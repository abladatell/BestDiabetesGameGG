using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    //Quits the game when the method is called.
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
