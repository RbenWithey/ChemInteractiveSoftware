using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderController : MonoBehaviour
{
    public TMP_Text valueText;
    //public Text valueText;

    public void OnSliderChanged(float value) //this float value is passed in whenever the value of the slider is changed. 
    {
        //single = float 
        //the component on value changed for the slider can pass a float with a new slider value to the set method. this is why onsliderchanged gets float as the new parameter. 

        valueText.text = value.ToString();  //value is passed in from slider when changed, is converted to string and added to tmp pro text box as text which in this case is the value text.  
    }
}
