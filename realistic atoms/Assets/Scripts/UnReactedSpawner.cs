using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
//using System;
using UnityEditor.UIElements;
using System.Net;
using UnityEngine.Assertions.Must;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

public class UnReactedSpawner : MonoBehaviour
{
    public List<GameObject> ToDestroyListAtom1 = new List<GameObject>();
    public GameObject gamearea;

    public GameObject unreactedSpawner;
    private GameObject new_atom;
    public GameObject Textbox1;
    
    public int AtomCount; //the number of atoms spawned
    public int AtomNumber; //the number of atoms we want to spawn
    public int EnteredAtomNumber; //the variable used to store the number of atoms entered
    public int MaxAtomLimit;
    //private GameObject[] TempArray;
    public int Atom_Per_Frame = 1; //everytime this script is run, how many atoms it is going to be creating


    private int AtomCheckValue = 1;
    public string PopUp;
    public string PopUp2;

    //this is to do with objects leaving view, but as in a container not needed, however could look into if we want to control spawning and despawning in an open area.

    public float spawn_circle_radius = 300.0f; //use this for random position of the atoms, use inside unit circle to find a random position anywhere within a circle
    public float death_circle_radius = 700.0f;
 

    bool AboveLimit;


    private void Start() //gets the input field from the TMP_input field component, and sets the text within it at zero so that a null error exception is not thrown. 
    {
        

        unreactedSpawner.tag = "Spawner";
        TMP_InputField TextComponent = Textbox1.GetComponent<TMP_InputField>();

        TextComponent.text = "0";
    }

    int OnEnterPressed() //when enter is pressed this section of code is run. finds the entered atom number from the value returned from the find new atom limit sub. and this is then returned to the update function. 
    {
        EnteredAtomNumber = FindNewAtomLimit();

        Debug.Log(EnteredAtomNumber); //this is the animation problem we were having video is dialog vox and pop up menu unity ui tutorial by clipper at around 14 mins.
        return EnteredAtomNumber;
    }


    // Update is called once per frame
    void Update() //checks every frame to see if the enter or return key is being held down. 
    {



        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)) //if the enter or return key is being held down
        {
           //put a do loop here once sorted the deleting problem
           
                AtomNumber = OnEnterPressed(); //atom number is returned from the on enter pressed sub

            Debug.Log("Atom number is " + AtomNumber);


            if (AtomNumber == -1) //if the atom number returned is -1, that means it was not in a valid format/data type/could not be parsed to an integer 
            {

                Debug.Log("Pop system loop entered");
                PopUpSystem pop = GameObject.FindGameObjectWithTag("Menu").GetComponent<PopUpSystem>(); //this finds the game object with the pop up system code on it 
                pop.PopUp(PopUp); //calls the popup function from the popup script and passes in pop up, which contains the error information. this means we can potentially have multiple messages displayed for multiple issues. 

            }
            else
            {

                Debug.Log("Maintain entered");
                MaintainPopulation(AtomNumber); //else we can go on and check how the inputted number will affect the population, or if it is too large.



               
            }



        }
   
       
        
    }

    int FindNewAtomLimit() //this sub firstly places a text string into the input field to prevent the code from accessing the it, and returning a null value exception. then it tries to parse the text in and turn it into a int
        // if the value is successfully parsed, and is bigger than or equal to 0, then we return a one to show the number entered is valid and returned, else we return a -1 to show it is not valid. 
    {
        
        string text = "0"; //temp text to fill input field 
        text = Textbox1.GetComponent<TMP_InputField>().text; //gets the input field text component. 
        int NumberTried;

        bool isNumber = int.TryParse(text, out NumberTried); //parses the text as an integer

        if (isNumber == true && NumberTried >= 0) //larger or equal to zero and has been successfully parsed
        {
            int number = int.Parse(text); //parses the text as an int again and then return it 
            return number;
        }
        else //else return a -1 to show it is not valid. 
        {

            return -1;
        }


        //Debug.Log("this is " + text);
        //possibly think about putting this on click function
   
        //so we find thw number of atom through this 
    }

    void ToDestroy() //this is called in order to destroy all of the atoms present in the collision theory scene 
    {


        //TempArray = GameObject.FindGameObjectsWithTag("Atom");

      


        Debug.Log("ToDestroy is entered");
        //int counter = 0;

        foreach (GameObject obj in ToDestroyListAtom1) //destroys all of the atom 1 game objects. 
        {
      
            Destroy(obj.gameObject);

            //counter += 1;
        }


        ToDestroyListAtom1.Clear();
        //and then call the add one for example. THIS IS WHERE YOU FINISHED ON THE 30 OF NOVEMBER HOPEFULLY WILL BE ABLE TO LOOK AT THIS TOMORROW. 
    }

    void ToCreate(int AtomNumber) //this sub is used to create the set amount (the atom number value passed in to the parameters) of atoms
    {
        for (int j = 0; j < AtomNumber; j++)
        {


            //this makes atoms but we need a way to remove them

            Vector3 position = GetRandomPosition(); //gets a random position value returned from the get random position sub. 
            new_atom = GenAtom(position, AtomCheckValue); //then generate the actual new_atom game object, passiong in the randomized position and atom check value as arguments.
            

            //new_atom.GetComponent<AtomScript>();
        }
    }

    void MaintainPopulation(int AtomNumber) //this sub is used to ensure the number of atoms currently present never exceeds the max atom limit set by me. 
    {

       

        if (AtomNumber > MaxAtomLimit) //if the atom number inputted by the user is more than the max atom limit then the above limit is set as true 
        {
            AboveLimit = true;
            PopUpSystem pop = GameObject.FindGameObjectWithTag("Menu").GetComponent<PopUpSystem>(); //this finds the game object with the pop up system code on it 
            pop.PopUp(PopUp2); //passes the string error message, in this case error message 2, to the pop up function, so it can be displayed to the user 
        }
        else //else it is not more than the above limit. 
        {
            AboveLimit = false;
        }

        //maybe make a sub for each of these if things, then call

        if (AtomCount < AtomNumber & AboveLimit == false) //if the atom count (number of atoms currently spawned) is less than the atom number and it is not above the atom limit (above limit is false), then we can go ahead and create the number of atoms needed.
        {

            //Debug.Log("Number entered is below 250 and larger than the original");
            ToCreate(AtomNumber);

            foreach (GameObject atomObj in GameObject.FindGameObjectsWithTag("Atom1")) //for each of the objects with the atom1tag, they are added to a destroy list, so that when we need to we can easily remove some or all of the atom1's from the population
            {
                ToDestroyListAtom1.Add(atomObj); //adds to list
                //atomObj.AddComponent<AddSpeedToMolecules>();
            }

        }

        if (AtomNumber < AtomCount) //if the number inputed is less than the number of atoms counted beforehand
        {
            ToDestroy(); //destroys all the atom 1's currently present
            ToCreate(AtomNumber); //create the number of atoms inputted. 

            foreach (GameObject atomObj in GameObject.FindGameObjectsWithTag("Atom1")) //once again all of these objects with the atom 1 tag are added to the destroy list so that it is easy to maintain the population
            {
                ToDestroyListAtom1.Add(atomObj);
                //atomObj.AddComponent<AddSpeedToMolecules>();
            }
        }

       

        //if (AtomCount < EnteredAtomNumber)
        //{



        //    for (int i = 0; i < Atom_Per_Frame; i++)
        //    {

        //        //this makes atoms but we need a way to remove them

        //        Vector3 position = GetRandomPosition();
        //        AtomScript new_atom = GenAtom(position);

        //        //new_atom.GetComponent<AtomScript>();
        //    }
        //}

        ////set up bool here to make sure this is only entered if it is not more than 250

        //if (MaxAtomLimit > EnteredAtomNumber)
        //{
        //    Debug.Log(EnteredAtomNumber + "Entered atom number");
        //    Debug.Log(MaxAtomLimit + "max atom limit");

        //    int difference = EnteredAtomNumber - MaxAtomLimit;

        //    Debug.Log(difference + " difference num");
        //    DestroyAtoms(difference);

        //    //so here we want to get the atom count, find how much it has gone over, and then delete these.
        //    //FIND A WAY HERE TO PRINT A WARNING. 
        //    //FIGURE OUT HOW TO PUT ONLY WHOLE INTEGERS INTO THE TEXT 
        //}
    }






    Vector3 GetRandomPosition() //this generates a random position to return to the create sub.
    {
        Vector3 position = UnityEngine.Random.insideUnitCircle; //the position is generated randomly within a specifically sized circle.

        position *= spawn_circle_radius; //the spawn circle radius multiples the position that has been generated - this means we can set how large the circle radius is and therefore what area within the atoms can spawn in. 
        position += gamearea.transform.position; //we then add the game area position, to ensure it is generated locally in the area. 

        return position; //position is then returned to the create sub. 
    }

    

     GameObject GenAtom(Vector3 position, int AtomCheckNumber) //this is the final sub before procedural generation. this calls the mesh generation code, passing in the random position we generated and the atom count number. it then rotates the new game object to the position calculated, and ensures it keeps its local orientation, and is not parented. 
     {
        //continue development and see if this continues 
        //figure out why the atom is not atom in the inspector, then continue at 17;54
        AtomCount += 1; //this is different in the unreacted spawner 2 script, and shows the program we are dealing with only atom 1's in this script. 
        //Debug.Log("Add atom " + position);
        new_atom = GetComponent<GenIcosphere>().CreateSphere(position, AtomCheckNumber); //this calls the create sphere sub in the gen icosphere script to make a new atom game object, passing in the randomly generated position we made and the atom check number so that the code knows to apply the correct materials. 
        
           
        //new_atom.transform.position = position;
        new_atom.transform.rotation = Quaternion.FromToRotation(Vector3.up, (gamearea.transform.position - position)); //we then give the new object a rotation, rotating from direction vector up to the game area pos - the pos of the gameobject. 
        //new_atom.transform.parent = new_atom.transform; //dont know why this is happening WE NEED TO FIGURE OUT HOW TO MAKE THE ATOM ITS SELF RATHER THAN THE UNREACTED SPANWER BECOMING THE PARENT AND THEREFORE BEING THE THING PUT IN THE LIST. <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        new_atom.transform.SetParent(null); //means the atoms are not set parent to anything. keeps its local orientation rather than its global orientation. 

        //new_atom.tag = "Atom";


        

        //adds the spawner instead of the atom object


        return new_atom; //returns the newly generated game object. 
        //sort out parent issue and why suddenly the mesh is a problem. might have been when we changed the position. 
        
      
     }


    //public void DestroyAtoms(int difference)
    //{
    //    GameObject objToDestroy;


    //    Debug.Log("first destroy atom one entered");

    //    Debug.Log(difference);

    //    for (int i = 0; i < difference; i++)
    //    {
    //        Debug.Log("Is this even entered");

    //        objToDestroy = UnReactedList[i];

    //        Destroy(objToDestroy);
    //    }
        
    //}
}


