using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBetweenCamera : MonoBehaviour

{
    public GameObject cam1;

    public GameObject cam2;


public void SwitchToElementCam()

    {
        cam1.SetActive(false);
        cam2.SetActive(true);
    }

  
}
