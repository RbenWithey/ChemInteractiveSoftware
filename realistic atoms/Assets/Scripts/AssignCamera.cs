using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject ElementObject in ElementObject.list)
        {
            ElementObject.GetComponentInChildren<Canvas>().worldCamera = Camera.main;
        }

        



    }

    
}
