using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetSpecificElementInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnStart(Element element) //parameter is saying i want a parameter that has a type of element (that has the element class). 
    {
        TMP_Text TextComponent = GetComponent<TMP_Text>(); //gets the TMP_Text component of the text box used in the 3d atom screen

        TextComponent.text = element.description; //this sets the text in the TMP_component as the text in the element description section of the scriptable object.
    }

}
