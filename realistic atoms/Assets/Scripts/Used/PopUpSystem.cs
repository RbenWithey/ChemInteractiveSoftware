using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpSystem : MonoBehaviour
{ //this script is used to print an error message when the input is 
    public GameObject popUpBox;
    public Animator Animator;
    public TMP_Text popUpText;

    public void PopUp(string text) //passes in the specific error message text to be put on the animation.
    {

        Debug.Log("Pop up script entered");
        popUpBox.SetActive(true); //activates the pop up box 
        popUpText.text = text; //sets the text used in the animation as the same as the error message text passed
        Animator.SetTrigger("pop"); //begins the pop animation. 


    }

}
