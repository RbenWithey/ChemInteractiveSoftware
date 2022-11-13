using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenIcosphere : MonoBehaviour
{

   

    private void Awake() //awake is run before start very clever man :)
    {
        //for (int i = 0; i < 10; i++)
        //{
            CreateSphere();
        //}

       

        Sphere.transform.position = new Vector3(0, 0, 1);
    }

    public PhysicMaterial BounceMat;
    public Material SphereMaterial;
    public float SphereSize = 1f;
    GameObject Sphere;
    Mesh SphereMesh;
    Vector3[] SphereVertices;
    int[] SpherTriangles;
    MeshRenderer SphereMeshRenderer;
    MeshFilter SphereMeshFilter;
    MeshCollider SphereMeshCollider;

    public void CreateSphere()
    {
        CreateSphereGameObject();
        //do whatever else you need to do with the sphere mesh
        RecalculateMesh();

        
    }

    void CreateSphereGameObject()
    {
        Sphere = new GameObject();
        SphereMeshFilter = Sphere.AddComponent<MeshFilter>();
        SphereMesh = SphereMeshFilter.mesh;
        SphereMeshRenderer = Sphere.AddComponent<MeshRenderer>();
        //need to set the material in inspector 
        SphereMeshRenderer.material = SphereMaterial;
        Sphere.transform.localScale = new Vector3(SphereSize, SphereSize, SphereSize);
        Icosphere.Create(Sphere, BounceMat);
    }

    void RecalculateMesh()
    {
        SphereMesh.RecalculateBounds();
        SphereMesh.RecalculateTangents();
        SphereMesh.RecalculateNormals();
    }
}
