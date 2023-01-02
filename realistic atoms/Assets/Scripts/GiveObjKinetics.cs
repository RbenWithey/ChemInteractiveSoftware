//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;
//using UnityEngine.PlayerLoop;

//public class GiveObjKinetics : MonoBehaviour
//{
//    //public float speed;
//    private List<GameObject> UnReactedList = new List<GameObject>();
//    public float speed;



//    private void Start()
//    {
//        UnReactedList = GameObject.FindGameObjectsWithTag("UnReactedTag").ToList();
//    }

    
//    // Update is called once per frame

//    private void FixedUpdate()
//    {
        

//        foreach (GameObject obj in UnReactedList)
//        {
          

//             Rigidbody rb = obj.GetComponent<Rigidbody>();
        
//             rb.AddForce(Vector3.up * speed);

//        }
//    }
//}
