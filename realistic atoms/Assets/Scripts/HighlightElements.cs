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


    public List<GameObject> AlkaliMetalsList = new List<GameObject>();
    public List<GameObject> AlkaliEarthMetalsList = new List<GameObject>();
    public List<GameObject> LanthanoidsList = new List<GameObject>();
    public List<GameObject> ActinidesList = new List<GameObject>();
    public List<GameObject> TransitionMetalsList = new List<GameObject>();
    public List<GameObject> MetalloidsList = new List<GameObject>();
    public List<GameObject> NonMetalsList = new List<GameObject>();
    public List<GameObject> NobleGasesList = new List<GameObject>();
    public List<GameObject> UnknownList = new List<GameObject>();
    public List<GameObject> PostTransitionMetalsList = new List<GameObject>();


    private List<GameObject> ElementList = new List<GameObject>();

    public Vector3 NormalScale = new Vector3 (100, 27.676f, 100);
    public GameObject ArrowObject;
    public GameObject PeriodicTableInfoButton;

    void Start()
        
    {
        ElementList = GameObject.FindGameObjectsWithTag("ElementTag").ToList();

        

        //GameObjectToWrite = ElementList.Find(x => x.name == ("Hydrogen"));

        //ArrowObject = ElementList.Find(x => x.name == ("arrow"));

        ////Debug.Log("This is the object we found " + GameObjectToWrite);

        //GameObjectToWrite.SetActive(false);

        //COULD USE THIS TO DISPLAY DIFFERENT INFO IN THE PERIODIC TABLE DISPLAY BOX.
    }

    public void AlkaliMetalButtonClick()

    {
        //ElementList.OrderBy(x => x.GetComponent<ElementObject>());
        ReturnToNormal();
        PeriodicTableInfoButton.SetActive(false);

        foreach (GameObject obj in AlkaliMetalsList)
        {
            obj.SetActive(true);
            obj.transform.localScale = NormalScale * 1.3f;
            
        }


    }

    public void LathanoidButtonClick()

    {
        //ElementList.OrderBy(x => x.GetComponent<ElementObject>());

        ReturnToNormal();
        PeriodicTableInfoButton.SetActive(false);

        foreach (GameObject obj in LanthanoidsList)
        {
            obj.SetActive(true);
            obj.transform.localScale = NormalScale * 1.3f;

        }

        ArrowObject.transform.localScale = new Vector3 (100,100,100);
        ArrowObject.SetActive(true);

    }

    public void ActinidesButtonClick()

    {
        //ElementList.OrderBy(x => x.GetComponent<ElementObject>());

        ReturnToNormal();
        PeriodicTableInfoButton.SetActive(false);

        foreach (GameObject obj in ActinidesList)
        {
            obj.SetActive(true);
            obj.transform.localScale = NormalScale * 1.2f;

        }

        ArrowObject.transform.localScale = new Vector3 (100,100,100);
        ArrowObject.SetActive(true);

    }

    public void AlkaliEarthMetalsButtonClick()

    {
        //ElementList.OrderBy(x => x.GetComponent<ElementObject>());

        ReturnToNormal();
        PeriodicTableInfoButton.SetActive(false);

        foreach (GameObject obj in AlkaliEarthMetalsList)
        {
            obj.SetActive(true);
            obj.transform.localScale = NormalScale * 1.3f;

        }


    }

    public void TransitionMetalsButtonClick()

    {
        //ElementList.OrderBy(x => x.GetComponent<ElementObject>());

        ReturnToNormal();
        PeriodicTableInfoButton.SetActive(false);

        foreach (GameObject obj in TransitionMetalsList)
        {
            obj.SetActive(true);
            obj.transform.localScale = NormalScale * 1.3f;

        }


    }
    public void PostTransitionMetalsButtonClick()

    {
        //ElementList.OrderBy(x => x.GetComponent<ElementObject>());

        ReturnToNormal();
        PeriodicTableInfoButton.SetActive(false);

        foreach (GameObject obj in PostTransitionMetalsList)
        {
            obj.SetActive(true);
            obj.transform.localScale = NormalScale * 1.3f;

        }


    }

    public void MetalloidsButtonClick()

    {
        //ElementList.OrderBy(x => x.GetComponent<ElementObject>());

        ReturnToNormal();
        PeriodicTableInfoButton.SetActive(false);

        foreach (GameObject obj in MetalloidsList)
        {
            obj.SetActive(true);
            obj.transform.localScale = NormalScale * 1.3f;

        }


    }
    public void NonMetalsButtonClick()

    {
        //ElementList.OrderBy(x => x.GetComponent<ElementObject>());

        ReturnToNormal();
        PeriodicTableInfoButton.SetActive(false);

        foreach (GameObject obj in NonMetalsList)
        {
            obj.SetActive(true);
            obj.transform.localScale = NormalScale * 1.3f;

        }


    }
    public void NobleGasesButtonClick()

    {
        //ElementList.OrderBy(x => x.GetComponent<ElementObject>());

        ReturnToNormal();
        PeriodicTableInfoButton.SetActive(false);

        foreach (GameObject obj in NobleGasesList)
        {
            obj.SetActive(true);
            obj.transform.localScale = NormalScale * 1.3f;

        }


    }
    public void UnknownButtonClick()

    {
        //ElementList.OrderBy(x => x.GetComponent<ElementObject>());

        ReturnToNormal();
        PeriodicTableInfoButton.SetActive(false);

        foreach (GameObject obj in UnknownList)
        {
            obj.SetActive(true);
            obj.transform.localScale = NormalScale * 1.3f;

        }


    }

    public void ResetButtonCLick()

    {
        //ElementList.OrderBy(x => x.GetComponent<ElementObject>());

        foreach (GameObject obj in ElementList)
        {
            obj.transform.localScale = NormalScale;
            obj.SetActive(true);
        }

        ArrowObject.transform.localScale = new Vector3(100, 100, 100);
        PeriodicTableInfoButton.SetActive(true);



    }

    public void ReturnToNormal()
    {
        foreach (GameObject obj in ElementList)
        {

            obj.SetActive(false);
            obj.transform.localScale = NormalScale;

        }

    }





    //.setactive(false)

}
