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
       
    }

    //IEnumerator waiter()
    //{
    //    yield return new WaitForEndOfFrame();

    //    transform.Rotate(new Vector3(60, 0, 0));

    //}

}//most successful idea so far
