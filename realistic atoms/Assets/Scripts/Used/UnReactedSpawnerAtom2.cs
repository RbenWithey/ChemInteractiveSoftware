using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnReactedSpawnerAtom2 : MonoBehaviour
{
    public List<GameObject> ToDestroyListAtom2 = new List<GameObject>();

    public GameObject gamearea;
    public GameObject unreactedSpawner;
    private GameObject new_atom2;
    public GameObject Textbox2;

    public int AtomCount2;
    public int AtomNumber2;
    public int EnteredAtomNumber2;
    public int MaxAtomLimit2;
    public int Atom2_PerFrame = 1;
    private int AtomCheckValue = 2; //used when generating the atom so it knows what tag and name to give to the object.
                                    
    public string PopUp;
    public string PopUp2;

    public float spawn_circle_radius = 300.0f; //use this for random position initial of the atoms, use inside unit circle to find a random position anywhere within a circle
    public float death_circle_radius = 700.0f;
      
    bool AboveLimit2;

    // Start is called before the first frame update
    private void Start()
    {
        unreactedSpawner.tag = "Spawner";
        TMP_InputField TextComponent = Textbox2.GetComponent<TMP_InputField>();

        TextComponent.text = "0";   
    }

    int OnEnterPressed()
    {
        EnteredAtomNumber2 = FindNewAtomLimit();
       
        return EnteredAtomNumber2;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            //put a do loop here once sorted the deleting problem

            AtomNumber2 = OnEnterPressed();

            Debug.Log("Atom number is " + AtomNumber2);


            if (AtomNumber2 == -1)
            {

                Debug.Log("Pop system loop entered");
                PopUpSystem pop = GameObject.FindGameObjectWithTag("Menu").GetComponent<PopUpSystem>();
                pop.PopUp(PopUp);

            }
            else
            {

                Debug.Log("Maintain entered");
                MaintainPopulation(AtomNumber2);

            }
        }
    }

    int FindNewAtomLimit()
    {

        string text = "0";
        text = Textbox2.GetComponent<TMP_InputField>().text;
        int NumberTried;

        bool isNumber = int.TryParse(text, out NumberTried);

        if (isNumber == true && NumberTried >= 0)
        {
            int number = int.Parse(text); 
            return number;
        }
        else
        {

            return -1;
        }

    }

    void ToDestroy()
    {
        Debug.Log("ToDestroy is entered");
       
        foreach (GameObject obj in ToDestroyListAtom2)
        {
            Destroy(obj.gameObject);

        }
        //take note of a bug that means if you enter the same number as the number you put before entering zero, the pop will not change. 
        ToDestroyListAtom2.Clear();
        
    }

    void ToCreate(int AtomNumber)
    {
        for (int j = 0; j < AtomNumber; j++)
        {
            Vector3 position = GetRandomPosition();
            new_atom2 = GenAtom(position, AtomCheckValue);
        }
    }

    void MaintainPopulation(int AtomNumber)
    {

        if (AtomNumber > MaxAtomLimit2)
        {
            AboveLimit2 = true;
            PopUpSystem pop = GameObject.FindGameObjectWithTag("Menu").GetComponent<PopUpSystem>(); //this finds the game object with the pop up system code on it 
            pop.PopUp(PopUp2);
        }
        else
        {
            AboveLimit2 = false;
        }


        if (AtomCount2 < AtomNumber & AboveLimit2 == false)
        {
            
            ToCreate(AtomNumber);

            foreach (GameObject atomObj in GameObject.FindGameObjectsWithTag("Atom2"))
            {
                ToDestroyListAtom2.Add(atomObj);
                //atomObj.AddComponent<AddSpeedToMolecules>();
            }

        }

        if (AtomNumber < AtomCount2)
        { 
            ToDestroy();
            ToCreate(AtomNumber);

            foreach (GameObject atomObj in GameObject.FindGameObjectsWithTag("Atom2"))
            {
                ToDestroyListAtom2.Add(atomObj);
                //atomObj.AddComponent<AddSpeedToMolecules>();
            }
        }

    }

    Vector3 GetRandomPosition()
    {
        Vector3 position = UnityEngine.Random.insideUnitCircle;

        position *= spawn_circle_radius;
        position += gamearea.transform.position;

        return position;
    }

    GameObject GenAtom(Vector3 position, int AtomCheckNumber)
    {
       
        AtomCount2 += 1;
       
        new_atom2 = GetComponent<GenIcosphere>().CreateSphere(position, AtomCheckNumber);
        new_atom2.transform.rotation = Quaternion.FromToRotation(Vector3.up, (gamearea.transform.position - position));
        new_atom2.transform.SetParent(null);
             
        return new_atom2;
       
    }

}
