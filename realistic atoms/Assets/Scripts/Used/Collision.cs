using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public Material MoleculeMaterial; //allows us to set the molecule material in the inspector (this is a yellow colour)
    AddSpeedToMolecules molSettingScript; //Stores the add speed to molecules script as molsettingscript
    Rigidbody rb; //stores the rigidbody of the object which has this script running on it. 

    private void Start() //this gives the game objects a random direction and works out the velocity for each of the objects with the collision script running on them
    {
        Vector3 randomPoint = transform.position + Random.onUnitSphere; //works out a random position within a sphere for each of the game objects with this script on it 
        Vector3 direction = randomPoint - transform.position; //a random direction is worked out for each of the objects, with this being achieved by taking the random point away from the position of the atom. this gives the direction
        rb = GetComponent<Rigidbody>(); //this is used to store the rigidbody component of the object 

        molSettingScript = GameObject.FindGameObjectWithTag("SliderTag").GetComponent<AddSpeedToMolecules>(); //find the current speed by getting the add speed to molecules script, which is on the slider (which has the slider tag)

        
        float slidertemp = molSettingScript.GetValue(); //we get the value from the add speed to molecules script, which initially is set to one
        rb.velocity = direction * 1; //this sets the starting velocity as 1, since if velocity started at zero, then no matter how large the multiplier was, the velocity would always remain at 0
        //Debug.Log(rb.velocity);
    }

    private void Update()
    {
        rb.velocity = (rb.velocity.normalized * molSettingScript.GetValue()) / 10; //every update we check if there has been a change in the value of the slider, and therefore if we need to change the velocity of the object. this is / by 10 to prevent the atoms from reaching a high speed, potentially causing them to clip throught the collider of the walls.
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
                

                ContactPoint contact = collision.GetContact(0); //gets the contact point at the specified index, which in this case is zero
                Debug.Log("contacts " + contact);
                Vector3 position = contact.point; //turns this contact index into a vector 3 position, therefore we now know where the collision occured. 

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

                Molecule.AddComponent<Collision>(); //adds the collision script to the molecule as well to ensure its speed can be modified like the atoms. 

                Atom1.transform.parent = Molecule.transform; //parents both of the atoms to the molecule. molecule acts as the parent 
                Atom2.transform.parent = Molecule.transform;

                Atom1.GetComponent<MeshRenderer>().material = MoleculeMaterial; //gives both the atoms the yellow molecule colour. 
                Atom2.GetComponent<MeshRenderer>().material = MoleculeMaterial;

                //rather than instantiating a new object and destroying the two old ones, just create a new gameobject and parent it to the two sepearate molecules, effectively allowing them to be glued together - like a bond. 

            }
        }
   
    }
}
