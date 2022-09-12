using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject cam1;

    public GameObject cam2;

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


    public void QuitGame()
    {

        Debug.Log("QUIT!");
        Application.Quit();

    }
}
