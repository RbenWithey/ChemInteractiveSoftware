using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HighlightElements : MonoBehaviour
{
    // Start is called before the first frame update
    //list of every element on the table
    //when certain button clicked, runs specific function for that button
    //original button to reset. 

    //for (int i = 0; i < ElementList.Count; i++)
    //{ 
    //    Debug.Log(ElementList[i]);
    //}

    private List<GameObject> ElementList = new List<GameObject>();


    void Start()
        
    {
        ElementList = GameObject.FindGameObjectsWithTag("ElementTag").ToList();
    }

    public void AlkaliMetalButtonClick()

    {
        ElementList.OrderBy(x => x.GetComponent<ElementObject>());
    }



    //.setactive(false)

    // Update is called once per frame
    void Update()
    {
        
    }
}
