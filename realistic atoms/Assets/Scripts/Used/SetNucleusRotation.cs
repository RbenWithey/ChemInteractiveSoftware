using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNucleusRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
       //this script ia used to set the rotation of the pivot as 90 degrees on the y axis
       //it is attached to rotate its y axis by 90 degrees, and because the pivot is the parent for the spawner spinning game object, the rotation is also applied to that and all of its children. this ensures the rings and electrons spawn at an angle i set and want to be seen by the user when they first click the respective element button. 
    }

}