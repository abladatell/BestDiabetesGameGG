using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public Collider col;

    // Start is called before the first frame update
    void Start()
    {
        col = gameObject.GetComponent<Collider>();
    }

    //Changes scene.
    void Update()
    {
        try
        {
            var cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("HitBox"));
            foreach (Collider c in cols)
            {
                if (c.name == "BodyCollider")
                {
                    SceneManager.LoadScene("Anadi Stahp Breaking shit", LoadSceneMode.Single);
                }
                else
                {
                    continue;
                }
            }
        }
        catch (System.Exception e)
        {
            //Nothing
        }
    }
}
