using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetSpecificElementInfo : MonoBehaviour

{
    
    // Start is called before the first frame update
    public void OnStart(Element element) //that parameter saying i want a parameter that has a type of element (that has the element class). 
    {
        TMP_Text TextComponent = GetComponent<TMP_Text>();

        TextComponent.text = element.description;
    }

}
