using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject cam1;
   
    public GameObject cam2;

    public GameObject cam3;


    public List<GameObject> LavoisierObjects = new List<GameObject>();
    public List<GameObject> DaltonObjects = new List<GameObject>();

    public GameObject PeriodicTableModel;


    public void Start()
    {
        

        foreach (GameObject obj in LavoisierObjects)
        {
            Debug.Log(obj);
        }
    }

    public void NextSceneInOrder()

    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //or possibly SceneManager.LoadScene(1) - this loads scene with build index
        //or SceneManager.LoadScene("name of scene);
    }

    public void ToMain()

    {
        SceneManager.LoadScene(0);
      
    }

    public void ToPeriodicT()

    {
        SceneManager.LoadScene(3);
       
    }


    public void PreviousSceneInOrder()

    {

      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }

    public void ToHydrogenInfo()

    {

        SceneManager.LoadScene("HydrogenInfo");

    }


    public void ToPreviousSceneInOrder()

    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }


    public void ToHeliumInfo()

    {

        SceneManager.LoadScene("HeliumInfo");

    }

    public void SwitchToElementCam()

    {
        cam2.SetActive(true);
        cam1.SetActive(false);
    
        
    }

    public void SwitchToPeriodicCam() 
    {
        cam1.SetActive(false);
        cam3.SetActive(true);

    }

    public void SwitchToPeriodicTableFull()
    {
        ResetImages();

        PeriodicTableModel.SetActive(true);

        cam1.SetActive(true);
        cam3.SetActive(false);

    }


    public void QuitGame()
    {

        Debug.Log("QUIT!");
        Application.Quit();

    }

    public void MiniPeriodicTable()
    {
        ResetImages();

        PeriodicTableModel.SetActive(true);
    }

    public void Lavoisier()
    {
        ResetImages();
        
        foreach (GameObject obj in LavoisierObjects)
        {
            obj.SetActive(true);
        }

        PeriodicTableModel.SetActive(false);
                       
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

    public void ResetImages() //rememember to add the list of objects to this when you make a new one. 
    {
        foreach (GameObject obj in LavoisierObjects)
        {
            obj.SetActive(false);
        }


        foreach (GameObject obj in DaltonObjects)
        {
            obj.SetActive(false);
        }
    }

}
