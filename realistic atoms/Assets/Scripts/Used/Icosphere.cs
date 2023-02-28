using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;



//this script is to do with actually making the mesh of the icosphere to be used by the mesh filter
public static class Icosphere //public - means it is visible from classes in other scripts. static class means it isnt attached to a specific instance of it. it is essential a function to create something. class is like a template for the instances made of it during runtime. 
{
    
    private struct TriangleIndices //declares a structure of integers to be used for triangle indices. 
    //a struct object is is very similar to a class, as an instance can be called from it, but different from a class because a struct type is a value type, and a class type is a reference type.
    //a struct is like a class that is used to store data
    {
        public int v1;
        public int v2;
        public int v3;

        public TriangleIndices(int v1, int v2, int v3) //1 of these represents the 3 vertices used to create a face
        {
            this.v1 = v1; //'this' refers to the class that is running the code. 
            this.v2 = v2;
            this.v3 = v3;
        }
    }

    // return index of point in the middle of p1 and p2
    private static int getMiddlePoint(int p1, int p2, ref List<Vector3> vertices, ref Dictionary<long, int> cache, float radius) //passes in 2 vertices points held in the triangle indices struct, a ref of the vert list, ref of the middle point index cache and the radius.
    {
        //first check if we have it already
        bool firstIsSmaller = p1 < p2; //if the first vertex in the triangle is smaller, true  
        long smallerIndex = firstIsSmaller ? p1 : p2; //smallerIndex = p1 if firstIsSmaller = true, and it equals p2 if it equals false
        long greaterIndex = firstIsSmaller ? p2 : p1; //greaterIndex = p2 if firstIsSmaller = true, and it equals p1 if it equals false
        long key = (smallerIndex << 32) + greaterIndex; //key is the smaller index bit shifted to the left by 32, essentially making it 2^32 + the greater index.

        int ret;

        if (cache.TryGetValue(key, out ret)) //this tries to get the value, ret, of the specified key. 
        {
            return ret; //return the middle point to be used
        }

        //if not in cache, calculate it
        Vector3 point1 = vertices[p1];
        Vector3 point2 = vertices[p2];
        Vector3 middle = new Vector3((point1.x + point2.x) / 2f, (point1.y + point2.y) / 2f, (point1.z + point2.z) / 2f); //caclulates the middle point 

        // add vertex makes sure point is on the unit sphere
        int i = vertices.Count;
        vertices.Add(middle.normalized * radius); //adds the new middle point to the vertices list, after it has been normalised and multiplied by the radius. 

        //store it, return index
        cache.Add(key, i); //we then add it to the middle point cache dictionary.

        return i; //return the newly found middle point after it has been added to the cache. 
    }

    public static void Create(GameObject gameObject, PhysicMaterial BounceMat, Vector3 position, int AtomCheckNumber, Material moleculeMaterial)
    {
       //put names and tags here 

        if (AtomCheckNumber == 1) //if the atom check number is one. 
        {
            gameObject.name = "UnReactedAtom1"; //if the atom check number is 1, the 'atom' being generated is of the the type atom 1 game object.

            gameObject.tag = "Atom1"; //adds atom 1 tag to make adding it to the list later on easier.
        }
        else
        {
            gameObject.name = "UnReactedAtom2"; //similar process except for atom 2

            gameObject.tag = "Atom2";
        }

        gameObject.transform.position = position; //the position is a randomized point in a circle in a previous script and pass through

        //this section here is addnig components to the game object in order for it to act like a sphere in collision theory 
        Rigidbody rb = gameObject.AddComponent<Rigidbody>(); //adds a rigidbody to the game object
        rb.useGravity = false; //allows it to float unless knocked or given kinetics.
        rb.constraints = RigidbodyConstraints.FreezePositionZ; //adds contraints to the rb to prevent it from moving on the z axis and therefore out of the 'reaction vessel' 
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous; //prevents clipping or other collision detection errors. 
        MeshFilter filter = gameObject.GetComponent<MeshFilter>(); //adds a mesh filter -stores the mesh data generated
        Mesh mesh = filter.mesh; //gets data for the mesh. the mesh consists of triangles arranged in 3D space to create the impression of a solid object
        mesh.Clear(); //this clears all vertex data and all triangle indices. this prevents issues from arisining before we rebuild the triangles array


        Vector3[] vertices = gameObject.GetComponent<MeshFilter>().mesh.vertices; //sets up a vector 3 array for the vertices, adding it to the mesh filter component
        List<Vector3> vertList = new List<Vector3>(); //sets up a list of vectors, used to store the vertices of the icosahedron
        Dictionary<long, int> middlePointIndexCache = new Dictionary<long, int>(); //sets up the cache for the middle point. use a dictionary as it is based in key-value correspondance - a key corresponds to a single value - makes it simpler
                                                                                   //suitable for nwhen you have a group of objects in a set (in this case the middle points).
        rb.isKinematic = false; //makes the rigid body of the gameobject non kinematic. 

        gameObject.AddComponent<Collision>(); //adds the collision script to each atom. 
        gameObject.GetComponent<Collision>().MoleculeMaterial= moleculeMaterial; //gets the molecule material component from the collision class. 

        int recursionLevel = 3; //this is how many times we want to re run the refining code of the program, in order to create more faces for the icosphere mesh and therefore improve its resolution. 
        float radius = 1f; //radius is how large we want the icosphere to be. 

        // create 12 vertices of a icosahedron
        float t = (1f + Mathf.Sqrt(5f)) / 2f;

        vertList.Add(new Vector3(-1f, t, 0f).normalized * radius); //vector2 positions of all of the vertices are multiplied by the radius to ensure the mesh, once generated, is the correct size
        vertList.Add(new Vector3(1f, t, 0f).normalized * radius);
        vertList.Add(new Vector3(-1f, -t, 0f).normalized * radius);
        vertList.Add(new Vector3(1f, -t, 0f).normalized * radius);

        vertList.Add(new Vector3(0f, -1f, t).normalized * radius);
        vertList.Add(new Vector3(0f, 1f, t).normalized * radius);
        vertList.Add(new Vector3(0f, -1f, -t).normalized * radius);
        vertList.Add(new Vector3(0f, 1f, -t).normalized * radius);

        vertList.Add(new Vector3(t, 0f, -1f).normalized * radius);
        vertList.Add(new Vector3(t, 0f, 1f).normalized * radius);
        vertList.Add(new Vector3(-t, 0f, -1f).normalized * radius);
        vertList.Add(new Vector3(-t, 0f, 1f).normalized * radius);


        // create 20 triangles of the icosahedron
        List<TriangleIndices> faces = new List<TriangleIndices>(); //creates a new list of the triangle indices struct called faces. used to add all of the faces when they are made

        // 5 faces around point 0
        faces.Add(new TriangleIndices(0, 11, 5)); //adds faces to the mesh
        faces.Add(new TriangleIndices(0, 5, 1));
        faces.Add(new TriangleIndices(0, 1, 7));
        faces.Add(new TriangleIndices(0, 7, 10));
        faces.Add(new TriangleIndices(0, 10, 11));

        // 5 adjacent faces 
        faces.Add(new TriangleIndices(1, 5, 9));
        faces.Add(new TriangleIndices(5, 11, 4));
        faces.Add(new TriangleIndices(11, 10, 2));
        faces.Add(new TriangleIndices(10, 7, 6));
        faces.Add(new TriangleIndices(7, 1, 8));

        // 5 faces around point 3
        faces.Add(new TriangleIndices(3, 9, 4));
        faces.Add(new TriangleIndices(3, 4, 2));
        faces.Add(new TriangleIndices(3, 2, 6));
        faces.Add(new TriangleIndices(3, 6, 8));
        faces.Add(new TriangleIndices(3, 8, 9));

        // 5 adjacent faces 
        faces.Add(new TriangleIndices(4, 9, 5));
        faces.Add(new TriangleIndices(2, 4, 11));
        faces.Add(new TriangleIndices(6, 2, 10));
        faces.Add(new TriangleIndices(8, 6, 7));
        faces.Add(new TriangleIndices(9, 8, 1));


        // refine triangles
        for (int i = 0; i < recursionLevel; i++) //recursion level is how many times the triangle faces are refined. 
        //recursion is used if the user wants to refine the icosphere further 

        {
            List<TriangleIndices> faces2 = new List<TriangleIndices>();  //creates a new list of the triangle indices struct called faces2, which is used to hold the new refined mesh of the icosphere, and then becomes the original list, if the mesh is refined further


            foreach (var tri in faces)
            {
                // replace triangle by 4 triangles
                int a = getMiddlePoint(tri.v1, tri.v2, ref vertList, ref middlePointIndexCache, radius); //this gets the middle point between two vertices (if it is not already found in the index cache) in order to refine the mesh and add more triangles. 
                int b = getMiddlePoint(tri.v2, tri.v3, ref vertList, ref middlePointIndexCache, radius);
                int c = getMiddlePoint(tri.v3, tri.v1, ref vertList, ref middlePointIndexCache, radius);
                //finds the middle point for all 3 sides of the triangle. 


                faces2.Add(new TriangleIndices(tri.v1, a, c)); //and then adds the new faces using the new middle points found, therefore refining the icosphere further. 
                faces2.Add(new TriangleIndices(tri.v2, b, a));
                faces2.Add(new TriangleIndices(tri.v3, c, b));
                faces2.Add(new TriangleIndices(a, b, c));
            }
            faces = faces2; //faces struct list becomes faces2 struct list and the statement begins again. 
        }

        mesh.vertices = vertList.ToArray(); //converts the vert list to an array and adds it to the mesh. 

        List<int> triList = new List<int>(); //creates an integer list

        for (int i = 0; i < faces.Count; i++)
        {
            triList.Add(faces[i].v1); //for each of the faces, adds 3 integers (v1,v2,v3) to the trilist list, which is then used to create the triangles for the mesh when the list is converted to an array
            triList.Add(faces[i].v2);
            triList.Add(faces[i].v3);
        }

        mesh.triangles = triList.ToArray(); //converts the triangle list to array and then adds it to the mesh
        mesh.uv = new Vector2[vertices.Length]; //adds UV to all the vertices

        Vector3[] normals = new Vector3[vertList.Count]; //sets up a new vector3 list which is used to store all the normals, with it being the same length as the vert list


        for (int i = 0; i < normals.Length; i++)
        {
            normals[i] = vertList[i].normalized; //for each of the vertex in the list, they are normalized and then added to the normals array
        }
            


        mesh.normals = normals; //adds the normals array to the normals of the mesh

        mesh.RecalculateBounds();
        mesh.RecalculateTangents();
        mesh.RecalculateNormals();

        gameObject.AddComponent<MeshCollider>(); //adds a mesh collider to the gameobject
        MeshCollider mc = rb.GetComponent<MeshCollider>(); //gets mesh collider from the rigidbody
        mc.convex = true; //makes the mesh collider convex
        mc.sharedMesh = mesh; //sets the mesh made as the mesh of the mesh collider.
        mc.material = BounceMat; //applies the bounce material to the material of the mesh collider
        mesh.Optimize(); //optimises the mesh -improves rendering. 

    }
}

