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

    //this is to do with objects leaving view, but as in a container not needed, however could look into if we want to control spawning and despawning in an open area.

    public float spawn_circle_radius = 300.0f; //use this for random position initial of the atoms, use inside unit circle to find a random position anywhere within a circle
    public float death_circle_radius = 700.0f;
    public float speed = 20.0f;
    public string TextEntered;
    bool AboveLimit;


    private void Start()
    {
        

        unreactedSpawner.tag = "Spawner";
        TMP_InputField TextComponent = Textbox1.GetComponent<TMP_InputField>();

        TextComponent.text = "0";
    }

    int OnEnterPressed()
    {
        EnteredAtomNumber = FindNewAtomLimit();

        Debug.Log(EnteredAtomNumber); //this is the animation problem we were having video is dialog vox and pop up menu unity ui tutorial by clipper at around 14 mins.
        return EnteredAtomNumber;
    }


    // Update is called once per frame
    void Update()
    {



        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
           //put a do loop here once sorted the deleting problem
           
                AtomNumber = OnEnterPressed();

            Debug.Log("Atom number is " + AtomNumber);


            if (AtomNumber == -1)
            {

                Debug.Log("Pop system loop entered");
                PopUpSystem pop = GameObject.FindGameObjectWithTag("Menu").GetComponent<PopUpSystem>();
                pop.PopUp(PopUp);

            }
            else
            {

                Debug.Log("Maintain entered");
                MaintainPopulation(AtomNumber);



               
            }



        }
   
       
        
    }

    int FindNewAtomLimit()
    {
        
        string text = "0";
        text = Textbox1.GetComponent<TMP_InputField>().text;
        int NumberTried;

        bool isNumber = int.TryParse(text, out NumberTried);

        if (isNumber == true && NumberTried >= 0)
        {
            int number = int.Parse(text); //this doesnt work
            return number;
        }
        else
        {

            return -1;
        }


        //Debug.Log("this is " + text);
        //possibly think about putting this on click function
   
        //so we find thw number of atom through this 
    }

    void ToDestroy()
    {


        //TempArray = GameObject.FindGameObjectsWithTag("Atom");

      


        Debug.Log("ToDestroy is entered");
        //int counter = 0;

        foreach (GameObject obj in ToDestroyListAtom1)
        {
      
            Destroy(obj.gameObject);

            //counter += 1;
        }


        ToDestroyListAtom1.Clear();
        //and then call the add one for example. THIS IS WHERE YOU FINISHED ON THE 30 OF NOVEMBER HOPEFULLY WILL BE ABLE TO LOOK AT THIS TOMORROW. 
    }

    void ToCreate(int AtomNumber)
    {
        for (int j = 0; j < AtomNumber; j++)
        {


            //this makes atoms but we need a way to remove them

            Vector3 position = GetRandomPosition();
            new_atom = GenAtom(position, AtomCheckValue);
            

            //new_atom.GetComponent<AtomScript>();
        }
    }

    void MaintainPopulation(int AtomNumber)
    {

       

        if (AtomNumber > MaxAtomLimit)
        {
            AboveLimit = true;
        }
        else
        {
            AboveLimit = false;
        }

        //maybe make a sub for each of these if things, then call

        if (AtomCount < AtomNumber & AboveLimit == false)
        {

            //Debug.Log("Number entered is below 250 and larger than the original");
            ToCreate(AtomNumber);

            foreach (GameObject atomObj in GameObject.FindGameObjectsWithTag("Atom1"))
            {
                ToDestroyListAtom1.Add(atomObj);
                //atomObj.AddComponent<AddSpeedToMolecules>();
            }

        }

        if (AtomNumber < AtomCount) //if the number inputed is less than the number of atoms counted beforehand
        {
            ToDestroy();
            ToCreate(AtomNumber);

            foreach (GameObject atomObj in GameObject.FindGameObjectsWithTag("Atom1"))
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






    Vector3 GetRandomPosition()
    {
        Vector3 position = UnityEngine.Random.insideUnitCircle;

        position *= spawn_circle_radius;
        position += gamearea.transform.position;

        return position;
    }

    

     GameObject GenAtom(Vector3 position, int AtomCheckNumber)
     {
        //continue development and see if this continues 
        //figure out why the atom is not atom in the inspector, then continue at 17;54
        AtomCount += 1;
        //Debug.Log("Add atom " + position);
        new_atom = GetComponent<GenIcosphere>().CreateSphere(position, AtomCheckNumber);
        
           
        //new_atom.transform.position = position;
        new_atom.transform.rotation = Quaternion.FromToRotation(Vector3.up, (gamearea.transform.position - position));
        //new_atom.transform.parent = new_atom.transform; //dont know why this is happening WE NEED TO FIGURE OUT HOW TO MAKE THE ATOM ITS SELF RATHER THAN THE UNREACTED SPANWER BECOMING THE PARENT AND THEREFORE BEING THE THING PUT IN THE LIST. <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        new_atom.transform.SetParent(null);

        //new_atom.tag = "Atom";


        

        //adds the spawner instead of the atom object


        return new_atom;
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


