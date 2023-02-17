using UnityEngine;
using System.Collections;

public class RotateNucleusShells : MonoBehaviour
{

	//this is used to rotate the rings and electrons around the nucleus, to create a more expressive 3d animation of the the entire atomic model
	//this script is placed on the spawner spinning - which is responsible for spawning in the electrons and rings, hence why the rotation is enacted on them. 
	//this rotation paired with the rotation caused by the rotate electron shell script creates rotating circular motion of electrons around the shells, whilst the shells and the electrons rotate around the nucleus (really rotating around the spawner spinning pos). 
	//this code is also used on the spawner for nucleus object, and spins the game object of all the neutrons and protons combined at a continuous speed, adding more detail to the supposed animation (though this animation is made using rotate at runtime).

	public bool spin; //this are all present in the inspector allowing me to change them at runtime. this is the bool to say that the object with the script on them to spin.
	public bool spinParent; //spin the parent object instead of the object this script is attached to
    public float speed = 10f; //this determines the speed at which the rotation occurs. 

	
	public bool clockwise = true; //can be changed in the inspector, if true spins clockwise, false anticlockwise
	public float direction = 1f; //this is the direction the object spins in, the higher the number, the faster the object changes direction. used in the rotate method as the angle of which the object will be rotated.


	// Update is called once per frame
	void Update()
	{


		if (spin) //if the spin bool is true 
		{
			if (clockwise) //if the clockwise bool is true 
			{
				if (spinParent) //if the bool spin parent is true
					transform.parent.transform.Rotate(Vector3.right, (speed * direction) * Time.deltaTime); //uses the rotate method in order to work out how much to rotate the parent object around a given axis (the vector) and the angle at which this is done (which is calculated by multiplying the speed by the direction and the time passed since the last frame to the current one. 
				else
					transform.Rotate(Vector3.right, (speed * direction) * Time.deltaTime); //else it spins the object the script is attached to using the same transform method. 
			}
			else //this section of code is the same, except the axis is the opposite direction allowing the object to rotate oppositely (and therefore anticlockwise direction). 
			{
				if (spinParent)
					transform.parent.transform.Rotate(-Vector3.right, (speed * direction) * Time.deltaTime); //oppisite direction caused by making the vector negative/the inverse of the value. 
				else
					transform.Rotate(-Vector3.right, (speed * direction) * Time.deltaTime);
			}
		}
	}
}