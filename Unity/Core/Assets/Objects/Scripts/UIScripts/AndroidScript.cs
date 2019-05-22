using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AndroidScript : MonoBehaviour
{
    public Image image1;
    public Image image2;
    public Image image3;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {

    //Android Code
#if UNITY_ANDROID

        //Makes the Images appear by changing alpha to 1
        Color color = image1.color;
        color.a = 1.0f;
        image1.color = color;

        color = image2.color;
        color.a = 0.8f;
        image2.color = color;

        color = image3.color;
        color.a = 1.0f;
        image3.color = color;

        color = text.color;
        color.a = 1.0f;
        text.color = color;
#endif


    }

}
