using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateElectronShells : MonoBehaviour //spin2 performs the exact same function as the spinnucleus script, however its values are slightly modified. both of the scripts running at the same time on the same spawner object creates the desired effect 
{ //this effect being the 
    public bool spin;
    public bool spinParent;
    public float speed = 10f;

   
    public bool clockwise = true;
    public float direction = 1f;
    

    // Update is called once per frame
    void Update()
    {


        if (spin)
        {
            if (clockwise)
            {
                if (spinParent)
                    transform.parent.transform.Rotate(Vector3.up, (speed * direction) * Time.deltaTime); //all of the original vectors are up 
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

