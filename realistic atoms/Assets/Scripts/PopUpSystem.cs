using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpSystem : MonoBehaviour
{ //this script is used to print an error message when the input is 
    public GameObject popUpBox;
    public Animator Animator;
    public TMP_Text popUpText;

    public void PopUp(string text)
    {

        Debug.Log("Pop up script entered");
        popUpBox.SetActive(true);
        popUpText.text = text;
        Animator.SetTrigger("pop");


    }





}
