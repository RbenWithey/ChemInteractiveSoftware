using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject cam1; //gameobject used to store the different cameras we have throughout the software so that we can easily access them throughout this main menu script.
    public GameObject cam2;
    public GameObject cam3;


    public List<GameObject> LavoisierObjects = new List<GameObject>();
    public List<GameObject> DaltonObjects = new List<GameObject>();
    public List<GameObject> DobereinerObjects = new List<GameObject>();
    public List<GameObject> NewlandsObjects = new List<GameObject>();
    public List<GameObject> MeyerObjects = new List<GameObject>();
    public List<GameObject> MendeleevObjects = new List<GameObject>();

    public GameObject PeriodicTableModel;


    public void NextSceneInOrder() //this is just a vague sub, which is used to go to the next scene in the build index.

    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //or possibly SceneManager.LoadScene(1) - this loads scene with build index
        //or SceneManager.LoadScene("name of scene);
    }

    public void ToMain() //this takes you to the main menu, which in this case is at the scene index 0.

    {
        SceneManager.LoadScene(0);
      
    }

    public void ToCollisionTheory() //this sub takes you to the collision theory scene, which in this case is scene index 2.
    {
        SceneManager.LoadScene(2);
    }

    public void ToPeriodicT() //this sub takes you to the periodic table scene, in this is scene index 1.

    {
        SceneManager.LoadScene(1); 
       
    }

    public void ToPreviousSceneInOrder() //this is another ambiguous ui sub, which can be used to move to the previous scene in the scene index. 

    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    } 

    public void SwitchToElementCam() //this sub is used to switch between the camera which is viewing the periodic table, and the camera in the 3D atom screen. 

    {
        cam2.SetActive(true);
        cam1.SetActive(false);
    }

    public void SwitchToPeriodicCam() //this is used to switch from the periodic table to the periodic table information screen. 
    {
        cam1.SetActive(false);
        cam3.SetActive(true);

    }

    public void SwitchToPeriodicTableFull() //this is used to switch back from the periodic table information screen to the periodic table. 
    {
        ResetImages(); //resets the images so that next time the camera switches the objects present in that scene are consistent. 

        PeriodicTableModel.SetActive(true); //sets the periodic table model as active 

        cam1.SetActive(true);
        cam3.SetActive(false);

    }


    public void QuitGame() //this is used to exit from the software
    {

        Debug.Log("QUIT!");
        Application.Quit();

    }

    public void MiniPeriodicTable() //this sets the mini periodic table model in the periodic table info screen as active and resets all the other images.
    {
        ResetImages();

        PeriodicTableModel.SetActive(true);
    }

    public void Lavoisier() //This code is used for all of the scientist buttons, in which is resets the images and then gets the image objects from the list of that respective scientist and sets them as active. 
    {
        ResetImages();
        
        foreach (GameObject obj in LavoisierObjects)
        {
            obj.SetActive(true);
        }

        PeriodicTableModel.SetActive(false); //sets the periodic table as false. 
                       
    }

    public void Dalton()
    {
        ResetImages();

        foreach (GameObject obj in DaltonObjects)
        {
            obj.SetActive(true);
        }

        PeriodicTableModel.SetActive(false);

    }

    public void Dobereiner()
    {
        ResetImages();

        foreach (GameObject obj in DobereinerObjects)
        {
            obj.SetActive(true);
        }

        PeriodicTableModel.SetActive(false);

    }

    public void Newlands()
    {
        ResetImages();

        foreach (GameObject obj in NewlandsObjects)
        {
            obj.SetActive(true);
        }

        PeriodicTableModel.SetActive(false);

    }

    public void Meyer()
    {
        ResetImages();

        foreach (GameObject obj in MeyerObjects)
        {
            obj.SetActive(true);
        }

        PeriodicTableModel.SetActive(false);

    }

    public void Mendeleev()
    {
        ResetImages();

        foreach (GameObject obj in MendeleevObjects)
        {
            obj.SetActive(true);
        }

        PeriodicTableModel.SetActive(false);

    }

    public void AtomicModel()
    {
        SceneManager.LoadScene(1); //loads the periodic table scene 
        cam2.SetActive(true); //sets the camera on the 3d atom screen as active 
        cam1.SetActive(false); //sets the camera on the periodic table as not active, therefore changing camera view

    }



    public void ResetImages() //rememember to add the list of objects to this when you make a new one. 
        //this sub resets the all the images in this screen in order to make sure the logic stays consistent. 

    {
        foreach (GameObject obj in LavoisierObjects) //gets all the objects for the respective scientist and sets them as false.
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in DaltonObjects)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in DobereinerObjects)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in NewlandsObjects)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in MeyerObjects)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in MendeleevObjects)
        {
            obj.SetActive(false);
        }
    }

}
