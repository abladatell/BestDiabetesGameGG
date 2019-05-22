using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputValidator : MonoBehaviour
{
    public userNameRememberer userNameRememberer;
    //Start Button image
    public Image image;

    //Gets data from input and calls the submitName method
    void Start()
    {
        var input = gameObject.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitName);
        input.onEndEdit = se;

        //or simply use the line below, 
        //input.onEndEdit.AddListener(SubmitName);  // This also works
    }
    //Assigns the data to a variable, and makes the start button display.
    private void SubmitName(string data)
    {
        userNameRememberer.userName = data;
        Color color = image.color;
        color.a = 1.0f;
        image.color = color;
       
    }
}
