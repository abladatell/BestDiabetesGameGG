using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NurseDescend : MonoBehaviour
{

    float nurseX;
    float nurseY;
    float nurseZ;
    Animator anim;
    float timer = 0f;
    public Text txt;

    // Start is called before the first frame update
    void Start()
    {
        nurseX = transform.position.x;
        nurseY = transform.position.y;
        nurseZ = transform.position.z;
        anim = GetComponent<Animator>();
    }

    // Final animation with nurse. Changes to endcredits after she descends.
    void Update()
    {
        timer = timer + 1 * Time.deltaTime;
        if (nurseY > 3)
        {
            Debug.Log("nurse");
            anim.SetTrigger("Float");
            nurseY = nurseY - 1 * Time.deltaTime;
            transform.position = new Vector3(nurseX, nurseY, nurseZ);
            Quaternion target = Quaternion.Euler(0, 270, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 5.0f);
        }
        else if (timer > 12)
        {
            SceneManager.LoadScene("EndCredits", LoadSceneMode.Single);
        }
    }
}
