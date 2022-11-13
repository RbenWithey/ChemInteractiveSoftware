//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[RequireComponent (typeof(MeshFilter), typeof(MeshRenderer))] //automatically adds the mesh filter and renderer as dependencies, useful to avoid setup errors 
//public class GeneratingSphereMesh : MonoBehaviour
//{
    
//    private Mesh mesh;
//    private Vector3[] vertices;

//    public int horizontalLines = 40;
//    public int verticalLines = 40;
//    public int radius;

//    private void Awake() //called when script instance is loaded -an instance is essential the ID of the script
//    {
//        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
//        mesh.name = "SphereMesh";
//        vertices = new Vector3[horizontalLines * verticalLines];
//        int index = 0;

//        for (int m = 0; m < verticalLines - 1; m++) //generates mesh
//        {
//            float mAngle = Mathf.PI * m / horizontalLines;

//            for (int n = 0; n < verticalLines - 1; n++)
//            {
//                float nAngle = 2 * Mathf.PI * n / verticalLines;

//                float x = Mathf.Sin(mAngle) * Mathf.Cos(nAngle);
//                float y = Mathf.Sin(mAngle) * Mathf.Sin(nAngle);
//                float z = Mathf.Cos(mAngle);
//                vertices[index++] = new Vector3(x, y, z) * radius;

//            }
//        }
        
        
//    }

//    private void OnDrawGizmos() //debugging only seen in editor view
//    {
//        Debug.Log("On draw gizmos entered");
//        if (vertices == null)
//        {
//            return;
//        }

//        for (int i = 0; i < vertices.Length; i++)
//        {
//            Debug.Log("Vertice" + i);
//            //try and get it to add the material to the mesh renderer as this may be why it is not showing up 
//            Gizmos.color = Color.black;
//            Gizmos.DrawSphere(transform.TransformPoint(vertices[i]), 0.1f);
//        }
//    }
//}
