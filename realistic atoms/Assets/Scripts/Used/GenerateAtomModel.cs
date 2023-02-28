using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class GenerateAtomModel : MonoBehaviour
{
    public GameObject spawnerfornucleus;
    public GameObject neutronstospawn;
    public GameObject protonstospawn;
    public GetSpecificElementInfo elementInfo;
   
    public void ButtonClick(Element element)
    {
        elementInfo.OnStart(element);

        Rigidbody rigidb;
        GameObject nucleusSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere); //this creates the sphere to spawn the neutrons and protons on, and stores it as the game object nucleusSphere

        nucleusSphere.transform.position = new Vector3(815f, -4.5f, 1.8f); //this gives the sphere a new position in the game world
        nucleusSphere.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f); //gives it a very small scale so is invisible to the naked eye. 
        nucleusSphere.transform.parent = spawnerfornucleus.transform; //makes the spawner its parent 

        nucleusSphere.AddComponent<Rigidbody>(); //adds a rigid body but makes sure it is not affected by gravity, this means it doesnt fall endlessly in the game world. 
        nucleusSphere.GetComponent<Rigidbody>().useGravity = false;

        
        Mesh.Destroy(nucleusSphere.GetComponent<MeshRenderer>()); //destroys the mesh of the nucleus sphere so is no longer able to be rendered. 
        rigidb = nucleusSphere.GetComponent<Rigidbody>(); //gets the rigid body of the nucleus sphere and freezes its position. 
        rigidb.constraints = RigidbodyConstraints.FreezePosition;

        int neutrons = element.Neutrons; //gets the number of neutrons and protons required to make the nucleus of the atom. 
        int protons = element.Protons;

        for (int i = 0; i < protons; i++) // < makes sure it runs until i is equal to the actual num of protons
            //for every number in proton, runs this code. 
        {
            //REMEMBER IF YOU MOVE THE POSITION OF THE ATOM TO MOVE THE VECTORS SO THEY SPAWN IN THE CORRECT PLACE.


            Vector3 ProtonSpawnPos = new Vector3(815, -4.51f, 1.8f); //gives the spawn position of the proton
            GameObject proton = Instantiate(protonstospawn, ProtonSpawnPos + Random.insideUnitSphere * 0.4f, Quaternion.identity, spawnerfornucleus.transform); //instantiates the proton in a random position (could be any point in a 0.4f diameter sphere from the proton spawn pos). gives it the same rotation as the parent object, and its parent is the spawner for nucleus)
            
            proton.AddComponent<CircularGravity>(); //adds circular gravity script to each of the protons made
            proton.GetComponent<CircularGravity>().nucleusSphere = nucleusSphere.transform; //this gives the position of the nucleus sphere to the circular gravity script. 

            if (protons == 1) //== in an if statement but not in a for , this if statement takes into account Hydrogen, basically if there is only one proton then we just place it in the nucleus sphere point and remove its grafity. 

            {
                proton.transform.position = new Vector3(815f, -4.5f, 1.8f);

                rigidb = proton.GetComponent<Rigidbody>();
                rigidb.constraints = RigidbodyConstraints.FreezePosition;

                //singular hydrogen moves due to gravity acting on the object
                Destroy(proton.GetComponent<CircularGravity>());
                //BRUH
                Destroy(spawnerfornucleus.GetComponent<RotateNucleusShells>());
            }




        }

        for (int i = 0; i < neutrons; i++) //similar process for neutron spawning 
        {

            Vector3 NeutronSpawnPos = new Vector3(815, -4.5f, 1.8f); //same spawn point 

            GameObject neutron = Instantiate(neutronstospawn, NeutronSpawnPos + Random.insideUnitSphere * 0.4f, Quaternion.identity, spawnerfornucleus.transform); //same instantiation code. 
            //neutron.AddComponent<BodyGravity>();
            //nucleusSphere.GetComponent<Attractor>().Attractors.Add(neutron.GetComponent<Attractor>());
            neutron.AddComponent<CircularGravity>();
            neutron.GetComponent<CircularGravity>().nucleusSphere = nucleusSphere.transform; //also given circular gravity script
            
        }


    }

   
}
