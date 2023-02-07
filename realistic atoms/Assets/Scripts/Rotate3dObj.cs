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

    //private void Start()
    //{
    //    rb.AddTorque(250, 50, 0);
    //}


    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0)) //when mouse is held down, storing the directional movement values of the mouse in float variables and multiplying them by a strength value
        {
            rotate = true;
            rotX = Input.GetAxis("Mouse X") * strength;
            rotY = Input.GetAxis("Mouse Y") * strength;
         
        }
        else
        {
            rotate = false;
        }
    }

    private void FixedUpdate()
    {
        if (rotate)
        {
            rb.AddTorque(rotY, -rotX, 0); //vector 3 so stores 3 bits of data 
        }   ///in this function, its applying the vertical mouse value to create rotational force around the x axis while the horizontal mouse value creates force around the y axis
    }
}


///code put into two sections as the physics based add torque should be in fioxed update so that the application of force is in sync with the physics steps of the game, the input checks, which are framerate dependent, need to be in update to work properly. 

///https://gamedevbeginner.com/how-to-rotate-in-unity-complete-beginners-guide/#rotate_rigidbody this is to rotate a rigid body using an add torque function
///for this to work we need a rigid body for the atom obj which we already do. give about 5 units of angular drag so stops relatively quickly.
///to rotate the object using the mouse, need to pass in the horizontal and vertical axis of the mouse input into the add torque function whenever the mouse button is down 