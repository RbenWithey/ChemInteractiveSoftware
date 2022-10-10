//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class AlkaliButtonClick : MonoBehaviour
//{

//    private bool fadeOut, fadeIn;

//    public float fadeSpeed;
    
    

//    // Update is called once per frame
//    void Update()
//    {

    
//        if(fadeOut)
//        {


//            Color objectColor = this.GetComponent<Renderer>().material.color;
//            float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

//            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
//            this.GetComponent<Renderer>().material.color = objectColor;

//            if (objectColor.a <= 0)
//            {
//                fadeOut = false;
//            }
//        }

//        if (fadeIn)
//        {
//            Color objectColor = this.GetComponent<Renderer>().material.color;
//            float fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

//            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
//            this.GetComponent<Renderer>().material.color = objectColor;

//            if (objectColor.a >= 0.70)
//            {
//                fadeIn = false;
//            }
//        }
//    }
//    //as adds to the colour value, we can use that as a boolean

//    public void FadeOutObject()        
//    { 
//        if (fadeOut == true)
//        {
//            FadeInObject(); //overflow here when spammed
//        }
//        fadeOut = true;
//    }
//    public void FadeInObject() //actually this one - this is button click
//    {
//        if (fadeIn == true) //used to be false here 
//        {
//            FadeOutObject(); 
//        }
//        fadeIn = true;
//    }

//}


/////////////https://owlcation.com/stem/How-to-fade-out-a-GameObject-in-Unity