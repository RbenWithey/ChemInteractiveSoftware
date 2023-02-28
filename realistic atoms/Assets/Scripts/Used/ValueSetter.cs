using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueSetter : MonoBehaviour
{
  
    void Start() //very simple script called when the scrollbar for the scrollable text box becomes active.
    {
        float ValueToChange = 1.0f; //this value is how far along the scrollbar is (1 being at the top, 0 at the bottom)
        
        ValueToChange = gameObject.GetComponent<Scrollbar>().value; //this gets the value of the scrollbars position and updates it to one when the scrollbar game object becomes active, ensuring it is always at the top of the text box when loaded.

        
    }


}
