using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnObjectsSphere : MonoBehaviour
{

    [SerializeField] private Slider _slider;

    int NumOfSpheres;

    public GameObject objectToSpawn;


    // Start is called before the first frame update
    public void OnValueChangedSlide()
    {
        NumOfSpheres = (int)_slider.value; //get component looks at only the object it is on 

        //make it add to a array/list, so when limit reached it stops. when change number remove all in the scene and replace with number

        Instantiate(objectToSpawn, transform.position, transform.rotation);
    }

 
}
