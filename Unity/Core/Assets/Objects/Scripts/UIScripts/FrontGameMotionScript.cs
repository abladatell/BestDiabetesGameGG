using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrontGameMotionScript : MonoBehaviour
{
    public float letterPause = 0.2f;

    string message;
    Text textComp;

    // Use this for initialization
    void Start()
    {
        //Gets the text component from the GameObject
        textComp = GetComponent<Text>();
        message = textComp.text;
        textComp.text = "";
        StartCoroutine(TypeText());
    }

    // Front Text animation, adds letter based on a delay.
    IEnumerator TypeText()
    {
        foreach (char letter in message.ToCharArray())
        {
            textComp.text += letter;
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
    }
}
