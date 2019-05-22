using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurseEmptyController : MonoBehaviour
{

    float nurseX;
    float nurseY;
    float nurseZ;
    Animator anim;
    float timer = 0f;
    bool start = false;

    // Start is called before the first frame update
    void Start()
    {
        nurseX = transform.position.x;
        nurseY = transform.position.y;
        nurseZ = transform.position.z;
        anim = GetComponent<Animator>();
    }

    // Animation script for the nurse.
    void Update()
    {
        timer = timer + 1 * Time.deltaTime;
        if (timer > 0.5f && timer < 1.5f && start == false)
        {
            Quaternion target = Quaternion.Euler(0, 180, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 5.0f);
        } else if (timer > 1.5f && start == false)
        {
            start = true;
            anim.SetTrigger("Walk");
        } else if (nurseZ > 1f && start == true)
        {
            nurseZ = nurseZ - 3f * Time.deltaTime;
            transform.position = new Vector3(nurseX, nurseY, nurseZ);
        } else if (nurseZ > 0f && start == true)
        {
            nurseX = nurseX + 1.5f * Time.deltaTime;
            nurseZ = nurseZ - 1.5f * Time.deltaTime;
            transform.position = new Vector3(nurseX, nurseY, nurseZ);
            Quaternion target = Quaternion.Euler(0, 90, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 5.0f);
        }
        else if (nurseX < 17f && start == true)
        {
            nurseX = nurseX + 3 * Time.deltaTime;
            transform.position = new Vector3(nurseX, nurseY, nurseZ);
            Quaternion target = Quaternion.Euler(0, 90, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 5.0f);
        }
        Debug.Log(start + " " + timer + " " + nurseZ);
    }
}
