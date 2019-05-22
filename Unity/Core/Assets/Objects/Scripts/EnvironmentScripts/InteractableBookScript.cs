using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableBookScript : MonoBehaviour
{
    public Image image;

    //Brings up the image on the screen if player is in collision range
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "BodyCollider")
        {
            var tempColor = image.color;
            tempColor.a = 1.0f;
            image.color = tempColor;
        }
    }

    //Takes down the image on the screen if player is out of collision range
    private void OnTriggerExit(Collider other)
    {
        var tempColor = image.color;
        tempColor.a = 0.0f;
        image.color = tempColor;
    }
}
