using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableBookScript : MonoBehaviour
{
    public Image image;

    
    private void OnTriggerEnter(Collider other)
    {
        var tempColor = image.color;
        tempColor.a = 1.0f;
        image.color = tempColor;
    }
    private void OnTriggerExit(Collider other)
    {
        var tempColor = image.color;
        tempColor.a = 0.0f;
        image.color = tempColor;
    }
}
