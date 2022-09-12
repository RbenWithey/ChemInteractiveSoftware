//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ChangeColour : MonoBehaviour
//{

//    //we want multiple cubes and cube renders to be stored and changed at the same time

//    public Renderer cubeRenderer; //this renders the cube we are going to change the colour of
//    public GameObject cubes;

//    [SerializeField] private Color newColour; //made it a serialized field so that we can change newcolour in the inspector


//    // Start is called before the first frame update
//    void Start()
//    {

//        cubeRenderer = cubeRenderer.GetComponent<Renderer>(); //getting the component of the cube we have rendered important as we are going to change the material/colour of this cube renderer
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }

//    public void ChangeMaterial() //this will tell the button to complete change material when the button is clicked 

//    {
//        cubeRenderer.material.color = newColour; 


//    }
//}
