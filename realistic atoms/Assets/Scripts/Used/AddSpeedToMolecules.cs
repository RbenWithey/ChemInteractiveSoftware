using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using TMPro;
using System.Text;
using System;
using UnityEngine.UI;

public class AddSpeedToMolecules : MonoBehaviour
{
    public Vector2 v;
    private int CurrentSpeed;

    
    private void Update() //every frame, we get the slider value component and update the value of the current speed variable. 
    {
        CurrentSpeed = (int)GetComponent<Slider>().value;
    }

    public float GetValue() //get value returns the current speed value (which is public and be accessed throughout all of the software. 
    {
        Debug.Log(CurrentSpeed);
        return CurrentSpeed; //returns this value to 
    }

 
}