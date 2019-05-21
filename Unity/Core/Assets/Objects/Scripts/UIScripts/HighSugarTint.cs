using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighSugarTint : MonoBehaviour
{
    public PlayerController pC;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (pC.health <= 50)
            {
                var tempColor = image.color;
                tempColor.r = 0.65f;
                tempColor.g = 0.08f;
                tempColor.b = 0.08f;
                tempColor.a = 0.5f - (float)pC.health/100;
                image.color = tempColor;
            }
            else if (pC.health >= 150)
            {
                var tempColor = image.color;
                tempColor.r = 0.615f;
                tempColor.g = 0.5f;
                tempColor.b = 0.05f;
                
                tempColor.a = 0.25f + (float)(pC.health-150)/ 100;
                image.color = tempColor;

            }
            else
            {
                var tempColor = image.color;
                tempColor.a = 0.0f;
                image.color = tempColor;
            }
        }
        catch(System.Exception e)
        {

        }
    }
}

