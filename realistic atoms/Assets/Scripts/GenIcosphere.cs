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
   
    public PhysicMaterial BounceMat;
    public Material SphereMaterial1;
    public Material SphereMaterial2;
    public float SphereSize = 1f;
    GameObject Sphere;
    Mesh SphereMesh;
    Vector3[] SphereVertices;
    int[] SpherTriangles;
    MeshRenderer SphereMeshRenderer;
    MeshFilter SphereMeshFilter;
    MeshCollider SphereMeshCollider;

    public GameObject CreateSphere(Vector3 position, int AtomCheckNumber)
    {
        //Debug.Log("Gen icosphere " + position);
        CreateSphereGameObject(position, AtomCheckNumber);
        //do whatever else you need to do with the sphere mesh
        RecalculateMesh();

        return gameObject;
    }

    void CreateSphereGameObject(Vector3 position, int AtomCheckNumber)
    {



        Sphere = new GameObject();
        SphereMeshFilter = Sphere.AddComponent<MeshFilter>();
        SphereMesh = SphereMeshFilter.mesh;
        SphereMeshRenderer = Sphere.AddComponent<MeshRenderer>();
        //need to set the material in inspector 

        if (AtomCheckNumber == 1)
        {
            SphereMeshRenderer.material = SphereMaterial1;
        }
        else
        {
            SphereMeshRenderer.material = SphereMaterial2;
        }
     
        Sphere.transform.localScale = new Vector3(SphereSize, SphereSize, SphereSize);
        Icosphere.Create(Sphere, BounceMat, position, AtomCheckNumber);
    }

    void RecalculateMesh()
    {
        SphereMesh.RecalculateBounds();
        SphereMesh.RecalculateTangents();
        SphereMesh.RecalculateNormals();
    }

    
}
