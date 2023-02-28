using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;





public class HighlightElements : MonoBehaviour
{ //this code is used to highlight the individual list of elements. when the respected button is clicked. 

    public List<GameObject> AlkaliMetalsList = new List<GameObject>(); //make all the individual lists for each group of elements is here. 
    public List<GameObject> AlkaliEarthMetalsList = new List<GameObject>();
    public List<GameObject> LanthanoidsList = new List<GameObject>();
    public List<GameObject> ActinidesList = new List<GameObject>();
    public List<GameObject> TransitionMetalsList = new List<GameObject>();
    public List<GameObject> MetalloidsList = new List<GameObject>();
    public List<GameObject> NonMetalsList = new List<GameObject>();
    public List<GameObject> NobleGasesList = new List<GameObject>();
    public List<GameObject> UnknownList = new List<GameObject>();
    public List<GameObject> PostTransitionMetalsList = new List<GameObject>();

    private List<GameObject> ElementList = new List<GameObject>(); //this list is for every element object

    public Vector3 NormalScale = new Vector3 (100, 27.676f, 100); //this saves the normal scale of the square object before it is changed.
    public GameObject ArrowObject; //game object is an 3d arrow shape, this is set in the inspector. 
    public GameObject ArrowObject2; //holds the second arrow game object in the periodic table scene, this is set in the inspector. 
    public List<GameObject> PeriodicTableInfo = new List<GameObject>(); //this is the gameobject list which holds the chunks of text at the top and bottom of the periodic table which is also set in the inspector. 
    private float ScaleMultiplier = 1.3f;

    

    void Start()
        
    {
        ElementList = GameObject.FindGameObjectsWithTag("ElementTag").ToList(); //finds the game objects with the element tag (this is all the square objects in the periodic table
    }

    public void AlkaliMetalButtonClick() //for each of the buttons, they all have a similar code

    {
        ReturnToNormal(); //this sub resets the periodic table, setting all the element square objects as false (not active in the scene) and rescales them. this prevents logic from failing

        foreach (GameObject obj in PeriodicTableInfo)
        {
            obj.SetActive(false); //sets the button and the other text chunks as false to prevent misclicks on the element and to remove clutter . 

        }

        foreach (GameObject obj in AlkaliMetalsList) //for each the element objects in the alkali metals group
        {
            obj.SetActive(true); //set as true - whilst all the other square objects are set as false. this means only the list of elements wanted can be seen.
            obj.transform.localScale = NormalScale * ScaleMultiplier; //slightly enlarges the scale of the objects in the alkali metal list, this way they are more prominent to the user. this is done by multiplying the normal scale of the objects by the scale multiplier.
            
        }
    }

    public void LathanoidButtonClick()

    {

        ReturnToNormal();

        foreach (GameObject obj in PeriodicTableInfo)
        {
            obj.SetActive(false); //sets the button and the other text chunks as false to prevent misclicks on the element and to remove clutter . 

        }

        foreach (GameObject obj in LanthanoidsList)
        {
            obj.SetActive(true);
            obj.transform.localScale = NormalScale * ScaleMultiplier;

        }

        ArrowObject.transform.localScale = new Vector3 (100,100,100);  //ensures the scale of the object remains the same. 
        ArrowObject.SetActive(true); //this ensures the arrow between the lanthanoid and actinides group is kept when those respected buttons are clicked.

    }

    public void ActinidesButtonClick()

    {

        ReturnToNormal();

        foreach (GameObject obj in PeriodicTableInfo)
        {
            obj.SetActive(false); //sets the button and the other text chunks as false to prevent misclicks on the element and to remove clutter . 

        }

        foreach (GameObject obj in ActinidesList)
        {
            obj.SetActive(true);
            obj.transform.localScale = NormalScale * ScaleMultiplier;

        }

        ArrowObject.transform.localScale = new Vector3 (100,100,100);
        ArrowObject.SetActive(true);

    }

    public void AlkaliEarthMetalsButtonClick()

    {

        ReturnToNormal();

        foreach (GameObject obj in PeriodicTableInfo)
        {
            obj.SetActive(false); //sets the button and the other text chunks as false to prevent misclicks on the element and to remove clutter . 

        }

        foreach (GameObject obj in AlkaliEarthMetalsList)
        {
            obj.SetActive(true);
            obj.transform.localScale = NormalScale * ScaleMultiplier;

        }


    }

    public void TransitionMetalsButtonClick()

    {

        ReturnToNormal();
        
        foreach (GameObject obj in PeriodicTableInfo)
        {
            obj.SetActive(false); //sets the button and the other text chunks as false to prevent misclicks on the element and to remove clutter . 

        }

        foreach (GameObject obj in TransitionMetalsList)
        {
            obj.SetActive(true);
            obj.transform.localScale = NormalScale * ScaleMultiplier;

        }


    }
    public void PostTransitionMetalsButtonClick()

    {

        ReturnToNormal();

        foreach (GameObject obj in PeriodicTableInfo)
        {
            obj.SetActive(false); //sets the button and the other text chunks as false to prevent misclicks on the element and to remove clutter . 

        }

        foreach (GameObject obj in PostTransitionMetalsList)
        {
            obj.SetActive(true);
            obj.transform.localScale = NormalScale * ScaleMultiplier;

        }


    }

    public void MetalloidsButtonClick()

    {

        ReturnToNormal();

        foreach (GameObject obj in PeriodicTableInfo)
        {
            obj.SetActive(false); //sets the button and the other text chunks as false to prevent misclicks on the element and to remove clutter . 

        }

        foreach (GameObject obj in MetalloidsList)
        {
            obj.SetActive(true);
            obj.transform.localScale = NormalScale * ScaleMultiplier;

        }


    }
    public void NonMetalsButtonClick()

    {

        ReturnToNormal();

        foreach (GameObject obj in PeriodicTableInfo)
        {
            obj.SetActive(false); //sets the button and the other text chunks as false to prevent misclicks on the element and to remove clutter . 

        }

        foreach (GameObject obj in NonMetalsList)
        {
            obj.SetActive(true);
            obj.transform.localScale = NormalScale * ScaleMultiplier;

        }


    }
    public void NobleGasesButtonClick()

    {

        ReturnToNormal();

        foreach (GameObject obj in PeriodicTableInfo)
        {
            obj.SetActive(false); //sets the button and the other text chunks as false to prevent misclicks on the element and to remove clutter . 

        }

        foreach (GameObject obj in NobleGasesList)
        {
            obj.SetActive(true);
            obj.transform.localScale = NormalScale * ScaleMultiplier;

        }


    }
    public void UnknownButtonClick()

    {
        ReturnToNormal();
        
        foreach (GameObject obj in PeriodicTableInfo)
        {
            obj.SetActive(false); //sets the button and the other text chunks as false to prevent misclicks on the element and to remove clutter . 

        }

        foreach (GameObject obj in UnknownList)
        {
            obj.SetActive(true);
            obj.transform.localScale = NormalScale * ScaleMultiplier;

        }

    }

    public void ResetButtonCLick() //this resets the periodic table to its original state.

    {

        foreach (GameObject obj in ElementList)
        {
            obj.transform.localScale = NormalScale;
            obj.SetActive(true);
        }

        ArrowObject.transform.localScale = new Vector3(100, 100, 100);
        ArrowObject2.transform.localScale = new Vector3(60.71263f, 63.50117f, 50);

        foreach (GameObject obj in PeriodicTableInfo)
        {
            obj.SetActive(true); //sets the button and the other text chunks as false to prevent misclicks on the element and to remove clutter . 

        }
    }

    public void ReturnToNormal() //this is used to reset the periodic table before each of the button clicks effects are applied. 
    {
        foreach (GameObject obj in ElementList) //for each of the game objects in the element list 
        {

            obj.SetActive(false); //they are all set as false when it comes to being active (this essentially removes them from the world). 
            obj.transform.localScale = NormalScale; //resets the scale of the objects. 

        }

    }

}
