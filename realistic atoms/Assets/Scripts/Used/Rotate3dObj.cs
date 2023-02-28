using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate3dObj : MonoBehaviour
{
    public Rigidbody rb;
    public float strength = 100;
    public float rotX;
    public float rotY;
    bool rotate;

    // Update is called once per frame
    private void Update() //check every frame to see if their is a mouse input.
    {
        if (Input.GetMouseButton(0)) //when mouse is held down, storing the directional movement values of the mouse in float variables and multiplying them by a strength value
        {
            rotate = true; //if we want the object with this script on it to rotate, then set as true 
            rotX = Input.GetAxis("Mouse X") * strength;
            rotY = Input.GetAxis("Mouse Y") * strength;
         
        }
        else
        {
            rotate = false; //otherwise if not then dont rotate the object. 
        }
    }

    private void FixedUpdate() //every fixed update, apply the force/torque to the object which uses the rotX and rotY values which were worked out earlier in the script. 
    {
        if (rotate)
        {
            rb.AddTorque(rotY, -rotX, 0); //vector 3 so stores 3 bits of data 
        }   //in this function, its applying the vertical mouse value to create rotational force around the x axis while the horizontal mouse value creates force around the y axis
    }
}


//code put into two sections as the physics based add torque should be in fioxed update so that the application of force is in sync with the physics steps of the game, the input checks, which are framerate dependent, need to be in update to work properly. 
//for this to work we need a rigid body for the atom obj which we already do. give about 5 units of angular drag so stops relatively quickly.
//to rotate the object using the mouse, need to pass in the horizontal and vertical axis of the mouse input into the add torque function whenever the mouse button is down 