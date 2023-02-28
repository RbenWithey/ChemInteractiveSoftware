using UnityEngine;
using System.Collections;

public class CircularGravity : MonoBehaviour
{

    public Transform nucleusSphere; //gets the position rotation and scale of the object through the inspector. 
    Vector3 targetDirection; //usesd to store the direction we want the atoms to move in. this means the atoms moves towards the object position that is specified (in this case being the nucleus sphere. 
    public int radius = 5; //radius of gravity 
    public int forceAmount = 500; //strength of force 
    public float gravity = 0; //gravity is not acting on the object when the value is 0. 
    private Rigidbody rb; //gets the rigid body of the respective neutron or proton that the script is attached to 
    private float distance; //distance used to calculate the gravity. 

    // Use for initialization
    void Start()
    {
        Physics.gravity = new Vector3(0, gravity, 0); //sets the global physics of gravity to 0
        rb = GetComponent<Rigidbody>(); //gets the rigid body component of whatever object has this script attached to it.
    }


    // Update called once per frame
    void FixedUpdate() //anything physics needs to be done in fixed update to run physics rather than being called every frame - this ensures the physics calculations are not affected by frame rate. it is called every fixed framerate frame, rather than every frame. prevents physic calculations from building up and causing problems/not being inacted properly. 
    { //this works out every fixed update the forces that need to be applied to the game objects with this code on it, in order for them to have a seemingly realistic gravitational force pull them in. 

        targetDirection = nucleusSphere.position - transform.position; // the nucleus sphere is the sphere object in the centre of the atom generation area. work out the vector from that to the position of each atom. Saves direction
        distance = targetDirection.magnitude; // Find distance between this object and target object
        targetDirection = targetDirection.normalized; // Normalize target direction vector

        //This is typically used for when you want to get a direction to something and don't want the distance included in the vector so you normalize it to only have the direction. The magnitude of the vector is aka the length.

        if (distance < radius) //if the distance is larger than the radius, than the force acting as gravity is worked out and applied to the object. 
        {
            rb.AddForce(targetDirection * forceAmount * Time.fixedDeltaTime); //adds the 'force' (in this case the force is acting as gravity) to every object which has the circular gravity script added to it. 
        }


    }
}