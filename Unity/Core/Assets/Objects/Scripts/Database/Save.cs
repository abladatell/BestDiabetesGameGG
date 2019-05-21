using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFirebaseUnity;
using SimpleFirebaseUnity.MiniJSON;


public class Save : MonoBehaviour
{

    public void save(string branch, string jsonItem)
    {
        Firebase firebase = Firebase.CreateNew("https://bestdiabetesgamegg.firebaseio.com");
        FirebaseQueue firebaseQueue = new FirebaseQueue(true, 3, 1f); // if _skipOnRequestError is set to false, queue will stuck on request Get.LimitToLast(-1).
        try
        {
            firebaseQueue.AddQueuePush(firebase.Child(branch, false), jsonItem, true);
        } catch (System.Exception e)
        {
            Debug.Log("Save error: " + e);
        }
        
    }

    public void save()
    {
        Firebase firebase = Firebase.CreateNew("https://bestdiabetesgamegg.firebaseio.com");
        FirebaseQueue firebaseQueue = new FirebaseQueue(true, 3, 1f); // if _skipOnRequestError is set to false, queue will stuck on request Get.LimitToLast(-1).
        try
        {
            firebaseQueue.AddQueuePush(firebase.Child("Testing", false), "{ \"Test\" : \"Success\"}", true);
        }
        catch (System.Exception e)
        {
            Debug.Log("Save error: " + e);
        }
    }
}
