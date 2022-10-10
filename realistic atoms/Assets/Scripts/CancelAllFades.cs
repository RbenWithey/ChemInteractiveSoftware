
//using JetBrains.Annotations;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;

//public class CancelAllFades : MonoBehaviour

//{
//    // Start is called before the first frame update

//    private List<GameObject> fadedObjects = new List<GameObject>();



//    //bool fadeOut;
//    public float fadeSpeed;

//    public void CancelFadeAllObjects()
//    {


//        fadedObjects = GameObject.FindGameObjectsWithTag("Fade").ToList();
//        //this definitely gets all the objects in the list
//        //then this is called first after the button click
     
//        //this should theoretically fade out all of the objects but it doesnt. in fact has messed up the program even more. 
//        foreach (GameObject obj in fadedObjects)
//        {




//            //fadeOut = true;

//            //if (fadeOut == true)
//            //{

//            Color objectColor = obj.GetComponent<Renderer>().material.color;

//            objectColor.a = 0;
//            //float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

//            //objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
//            //obj.GetComponent<Renderer>().material.color = objectColor;

//            //if (objectColor.a <= 0)
//            //{
//            //    fadeOut = false;

//            //}
//            //}
//        }


//    }


//}
