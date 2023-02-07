using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GenIcosphere : MonoBehaviour
{

    //private void Awake() //awake is run before start very clever man :)
    //{
    //    //for (int i = 0; i < 10; i++)
    //    //{
    //        CreateSphere();
    //    //}



    
    //}
   
    public PhysicMaterial BounceMat; //all these materials are entered in the inspector. 
    public Material SphereMaterial1;
    public Material SphereMaterial2;
    public Material MoleculeMaterial;
    public float SphereSize = 0.5f; //this is the diameter of the sphere.
    GameObject Sphere; //creates a gameobject called sphere 
    Mesh SphereMesh; //also makes the mesh for the sphere
    Vector3[] SphereVertices; //the vector list for the sphere vertices. 
    int[] SpherTriangles; //integer list of the triangles used to make icosphere. 
    MeshRenderer SphereMeshRenderer; //creates a mesh renderer for the sphere. 
    MeshFilter SphereMeshFilter; //creates a mesh filter. 
    MeshCollider SphereMeshCollider; //adds a mesh collider to sphere. 

    public GameObject CreateSphere(Vector3 position, int AtomCheckNumber) //this is where the script is entered.
    {
        //Debug.Log("Gen icosphere " + position);
        CreateSphereGameObject(position, AtomCheckNumber); //passes in the position of where to spawn, and the atom check number. the atom check number tells the program whether or not is it being spawned from input1 or input2.
        //do whatever else you need to do with the sphere mesh
        RecalculateMesh(); //calls recalculate mesh sub

        return gameObject;
    }

    void CreateSphereGameObject(Vector3 position, int AtomCheckNumber)
    {



        Sphere = new GameObject(); //creates a new sphere gameobject
        SphereMeshFilter = Sphere.AddComponent<MeshFilter>(); //adds a sphere mesh filter to it
        SphereMesh = SphereMeshFilter.mesh; //gets the mesh from the sphere mesh filter
        SphereMeshRenderer = Sphere.AddComponent<MeshRenderer>(); //adds a renderer to the mesh so that it can be seen. 
        //need to set the material in inspector 

        if (AtomCheckNumber == 1) //if the atom check number is 1
        {
            SphereMeshRenderer.material = SphereMaterial1; //gives the sphere a red material
        }
        else
        {
            SphereMeshRenderer.material = SphereMaterial2; //else it must be atom 2 and therefore requires a green material 
        }
     
        Sphere.transform.localScale = new Vector3(SphereSize, SphereSize, SphereSize); //transforms the size of the sphere by the scale set in inspector. 
        Icosphere.Create(Sphere, BounceMat, position, AtomCheckNumber, MoleculeMaterial); //makes an instance of the icosphere class and calls the create sub, passing in the sphere gameobject, Bounce physic material, position, atom check number and the molecule material
    }

    void RecalculateMesh()
    {
        SphereMesh.RecalculateBounds(); //after modifying vertices you should call this function in order to ensure the bounding volume is correct. 
        SphereMesh.RecalculateTangents(); //this recalculates the tangents of the mesh from the normals and texture coordinates. after modifying the vertices and the normals of the mesh, tangents need to be updated if the mesh is rendered using shaders that reference normal maps. 
        SphereMesh.RecalculateNormals(); //recalculates the normals of the mesh from triangles and vertices. a normal is a vector that points outward, perpendicular to the mesh surface at the position of the vertex it is associated with. during the shading calculation each vertex normal is compared with the direction of the incoming light which is also a vector. 
    }

    
}
