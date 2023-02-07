using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using TMPro;
using System.Text;
using System;
using UnityEngine.UI;

public class AddSpeedToMolecules : MonoBehaviour
{
    public Vector2 v;
    private Vector2 direction;

    private int CurrentSpeed;

    //// Start is called before the first frame update
    //void Start() //goes weird in fixed update, check discord to see website, as i believe the author mentions something about mass
    //{
    //    //direction = RandomUnitVector();

    //    //transform.position = direction * Speed * Time.deltaTime;

    //    //we need a random direction, not random speed. 




    //    v = new Vector2(0, 10);

    //    v = v.normalized; //this should give me constant velocity
    //    v *= Speed;
    //    GetComponent<Rigidbody>().velocity = v * Random.onUnitSphere; //this is what is causing the rigidbody error. 

    //private void Start()
    //{
    //    int speed = 10;

    //    UpdateSpeedOfMolecules(speed);
    //}


    private void Update()
    {
        CurrentSpeed = (int)GetComponent<Slider>().value;
    }

    public float GetValue()
    {
        Debug.Log(CurrentSpeed);
        return CurrentSpeed;
    }

    public void CheckCurrentSetSpeed(int valuetostring) //so this should get the speed of the thing now we need to make it be called whenever the value changes. 
    {

        int speed = valuetostring;

        //Debug.Log("Current Temp is " + speed);

        //GetComponent<AddSpeedToMolecules>().UpdateSpeedOfMolecules(speed);

        UpdateSpeedOfMolecules(speed);
        CurrentSpeed = speed;
        //int CurrentSpeed = GetComponent<SliderController>().CheckCurrentSetSpeed();7

    }


    //    //gradually loses velocity over time

    //}

    public List<GameObject> MovingObjectsSpeed = new List<GameObject>();

    public void UpdateSpeedOfMolecules(int speed)
    {
        Debug.Log(speed);
        MovingObjectsSpeed.Clear();


        foreach (GameObject atomObj in GameObject.FindGameObjectsWithTag("Atom1"))
        {
            MovingObjectsSpeed.Add(atomObj);

        }

        foreach (GameObject atomObj in GameObject.FindGameObjectsWithTag("Atom2"))
        {
            MovingObjectsSpeed.Add(atomObj);

        }

        foreach (GameObject atomObj in GameObject.FindGameObjectsWithTag("Molecule"))
        {
            MovingObjectsSpeed.Add(atomObj);

        }

        //Debug.Log("Speed we are trying to change it to is " + speed);

        //need to get a list of the atom and the molecules, perhaps look for the tag and then add to the list
        //then we need to go through the list and add the new velocity to each of the atoms/molecules. 

        //int CurrentSpeed = GetComponent<SliderController>().CheckCurrentSetSpeed();


        //added all the moving object to the list and the speed when it changes. 


        foreach (GameObject atomObj in MovingObjectsSpeed)
        {
            Debug.Log("this is entered?");
            //add a random direction to all of them 

            //current problems is sorting out the list and then changing the speed of the objects in the list. 

            v = v.normalized; //this should give me constant velocity. normalising removes length. if direction is 0, then speed * 0 is also 0. 
            v *= speed;
            //atomObj.GetComponent<Rigidbody>().velocity = v;

            Debug.Log("this is the value of v " + v);

        }

        //we need a list of moving objects, but we cant add them to the list each time the slider changes otherwise it just fills the list to no end. 
        //plan to go through the list and individually give all moving objects the same speed. 
    }

}