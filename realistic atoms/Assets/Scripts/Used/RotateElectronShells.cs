using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateElectronShells : MonoBehaviour //RotateElectronShells performs the exact same function as the RotateNucleus script, however its values are slightly modified. 
{ 

    //this script is used in order to rotate the shell objects and all of their electrons object around in a circle on a centre point (this being the spawner spinning), whilst the other script is responsible for creating an effect of the subshells rotating around the nucleus. whilst the atom is on screen, three separate rotation scripts are running. 
    //the circular rotation makes it seem only the electrons are rotating, whereas the rings are too    

    public bool spin;
    public bool spinParent;
    public float speed = 10f;

   
    public bool clockwise = true;
    public float direction = 1f;
    

    // Update is called once per frame
    void Update() //every frame we check the bools to see if we enter specific parts of the code, and apply the rotate function to the transform of the object. 
    {


        if (spin)
        {
            if (clockwise)
            {
                if (spinParent)
                    transform.parent.transform.Rotate(Vector3.up, (speed * direction) * Time.deltaTime); //all of the original vectors are up. this causes the rings and electrons to rotate in circles
                else
                    transform.Rotate(Vector3.up, (speed * direction) * Time.deltaTime);
            }
            else
            {
                if (spinParent)
                    transform.parent.transform.Rotate(-Vector3.up, (speed * direction) * Time.deltaTime);
                else
                    transform.Rotate(-Vector3.up, (speed * direction) * Time.deltaTime);
            }
        }
    }
}

