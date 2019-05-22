using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurseController : MonoBehaviour
{
    public GameObject nurse;
    public GameObject insulin;
    float nurseX = 17f;
    float nurseY = 1f;
    float nurseZ = 0f;
    Animator anim;
    bool placed = false;
    bool placedAnim = false;
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // for the animation scene in the begging. Controls position and animations.
    void Update()
    {
        if (nurseX > -3f) {
            nurseX = nurseX - 3 * Time.deltaTime;
            transform.position = new Vector3(nurseX, nurseY, nurseZ);
        } else if (nurseX > -4f && nurseX < -3f) {
            nurseX = nurseX - 1.5f * Time.deltaTime;
            nurseZ = nurseZ + 1.5f * Time.deltaTime;
            transform.position = new Vector3(nurseX, nurseY, nurseZ);
            Quaternion target = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 5.0f);
        } else if (nurseX < -3f && nurseZ < 4.75f)
        {
            nurseZ = nurseZ + 3f * Time.deltaTime;
            transform.position = new Vector3(nurseX, nurseY, nurseZ);
        } else if (nurseZ > 4.5f)
        {
            timer = timer + 1 * Time.deltaTime;
            if (placedAnim == false)
            {
                anim.SetTrigger("Place");
                placedAnim = true;
            }
            if (timer > 0.7f && placed == false)
            {
                Instantiate(insulin, new Vector3(-4.25f, 2.5f, 6.5f), Quaternion.identity);
                placed = true;
            }
            if (placed == true && placedAnim == true)
            {
                Instantiate(nurse, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
