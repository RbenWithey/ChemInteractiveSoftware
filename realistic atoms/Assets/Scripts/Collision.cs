using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Collision : MonoBehaviour
{
    //private void OnTriggerEnter(Collider collision)
    //{
    //    if (collision.gameObject.CompareTag("Atom1"))
    //    {
    //        CollisionBetweenMolecules();
    //    }
    //}

    //both have different argument types (one collider and one collision) - means you can access the compare method directly on one (can just put collision.comparetag on on triggerenter)
    //private void OnCollisionEnter(UnityEngine.Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Atom1"))
    //    {
    //        CollisionBetweenMolecules();

    //    }
    //}


    public Material MoleculeMaterial;


    AddSpeedToMolecules molSettingScript;
    Rigidbody rb;

    private void Start()
    {
        Vector3 randomPoint = transform.position + Random.onUnitSphere;
        Vector3 direction = randomPoint - transform.position; 
        rb = GetComponent<Rigidbody>();

        molSettingScript = GameObject.FindGameObjectWithTag("SliderTag").GetComponent<AddSpeedToMolecules>();

        
        float slidertemp = molSettingScript.GetValue();
        rb.velocity = direction * 1;
        //Debug.Log(rb.velocity);
    }

    private void Update()
    {
        rb.velocity = (rb.velocity.normalized * molSettingScript.GetValue()) / 10;
    }

    private void OnCollisionEnter(UnityEngine.Collision collision) //on collision is run when there is a collision between two objects rigidbodys. passes in the objects collision class, which contains information such as contact points and impact velocity. 
    {
        string Tag = gameObject.transform.tag; //gets the tag of the object involved in the collision. 

        if (Tag == "Atom1") //if the tag is Atom1 (meaning the collision occured on atom 1)
        {

            GameObject Atom1 = gameObject; //this sets the game object that is known to have been in the collision to be known as atom1 

            if (collision.gameObject.CompareTag("Atom2")) //if the tag of the other object in the collision is atom2, then we know that atom 1 has collided with atom 2. 
            {
                Debug.Log("Atom 1 hit Atom 2 "); //find a way to make sure if both molecules have the tag then dont class as a collision to merge 
                GameObject Atom2 = collision.gameObject; //therefore the collision object must be atom2. 

                Atom1.tag = "InMolecule"; //this gives the objects a new inmolecule tag
                Atom2.tag = "InMolecule"; 
                

                ContactPoint contact = collision.GetContact(0); //gets the contact point at the specified index
                Vector3 position = contact.point; //turns this point into a vector 3 position, therefore we now know where the collision occured. 

                //Molecule = new GameObject();

                Vector3 resultantVelocity = Atom1.GetComponent<Rigidbody>().velocity + Atom2.GetComponent<Rigidbody>().velocity;
                //resultant velocity is worked out by getting the velocity of atom1's rigid body + the velocity of atom2's rigidboy


                GameObject Molecule = GameObject.CreatePrimitive(PrimitiveType.Sphere); //how to create a new empty game object. sphere is invisible and acts as the parent to the two molecules, allowing them to bind to each other. 
                Molecule.transform.position = position; //changes the position of where the sphere was instatiated to the position of where the collision occured. 

                Molecule.AddComponent<Rigidbody>(); //setting up new properties of the molecule sphere rb.
                Molecule.GetComponent<Rigidbody>().useGravity = false;
                Molecule.GetComponent<Rigidbody>().velocity = resultantVelocity; //gives it new velocity
                Molecule.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ; //prevents it from moving from the z axis it is already on. 

                Molecule.tag = "Molecule"; //gives the sphere the tag and name molecule
                Molecule.name = "Molecule";

                Destroy(Molecule.GetComponent<MeshRenderer>()); //destroys the sphere primitive and its properties.
                Destroy(Molecule.GetComponent<Collider>());
                Destroy(GetComponent<Rigidbody>());
                Destroy(collision.gameObject.GetComponent<Rigidbody>());

                Molecule.AddComponent<Collision>();


                Atom1.transform.parent = Molecule.transform; //parents both of the atoms to the molecule. molecule acts as the parent 
                Atom2.transform.parent = Molecule.transform;

                Atom1.GetComponent<MeshRenderer>().material = MoleculeMaterial; //gives both the atoms the yellow molecule colour. 
                Atom2.GetComponent<MeshRenderer>().material = MoleculeMaterial;

                //change colour to purple.

                //rather than instantiating a new object and destroying the two old ones, just create a new gameobject and parent it to the two sepearate molecules, effectively allowing them to be glued together - like a bond. 

            }
        }
        //else if (Tag == "Atom2")
        //{
        //    if (collision.gameObject.CompareTag("Atom1"))
        //    {
        //        Debug.Log("Atom 2 hit Atom 1 "); //find a way to make sure if both molecules have the tag then dont class as a collision to merge 
        //    }
        //}
       
    }




    //void ProcessCollision (GameObject collider)
    //{
    //    if (collider.CompareTag("Atom1"))
    //    {
    //          CollisionBetweenMolecules();

    //    }
    //}


    //void CollisionBetweenMolecules()
    //{
    //    Debug.Log("Collision");
    //}
}
