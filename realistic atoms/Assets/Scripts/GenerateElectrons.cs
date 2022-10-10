using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ElectronPosition
{
    public float EDistance;
    public Quaternion EAngle;
}


public class GenerateElectrons : MonoBehaviour
{
    public Vector3 electronVector;

    //change the z to move the electrons slightly
    //REMEMBER INSPECTOR VARIABLES OVERRIDES THESE DEFAULTS SO MAKE SURE TO ADD ELECTRON POSITION IN INSPECTOR
    //public List<Vector3> electronPosition = new List<Vector3>() { new Vector3(815.1f, -4.5f, 1.8f), new Vector3(814.9f, -4.5f, 1.8f), new Vector3(815.01f, -4.6f, 1.8f), new Vector3(815, -4.6f, 1.8f) };

    public GameObject spawnerspinning;
    public GameObject electronstospawn;
    public GameObject ringstospawn;
    GameObject nucleusSphere;


    //NOTE WE CHANGE RADIUS TO 0.01F FROM 0.0995F

    [Range(3, 360)]
    private int segments = 360; //how many segments the ring is made up of. the more segments, the smoother/rounder the edge. in general, no need to be so many as 360 but as a circle. has to be set to 3 otherwise range wont be set and will default to zero leading to issues
    public float innerRadius = 0.01f;  //how far away from the centre of the planet the rings start (for higher principle energy levels, increase this). at 0.7 as a basic sphere in unity is half a unit radius, gives breathing room  
    private float thickness = 0.005f; //how wide the ring will be 
    public Material ringMat; //allows us to give the orbit a texture/material of whatever we want
    public float progress;
    public float angle;
    float electronAngleAsFloat;
    Quaternion electronRotation;
  

    //cached references (so that we can easily access parts of the ring as they arent technically part of the nucleus)

    GameObject ring;
    Mesh ringMesh;
    MeshFilter ringMF; //component that holds the mesh
    MeshRenderer ringMR; //not public, so if need to access from somewhere else, make them public or properties that can access them


    public void ButtonClick(Element element)
    {

        int TotalElectrons = element.electronsS1 + element.electronsS2 + element.electronsS3 + element.electronsS4 + element.electronsS5 + element.electronsS6 + element.electronsS7;
        int shells = element.shells;
        Vector3 centre = spawnerspinning.transform.position;
       // float electronRadius;

        //i is the index in this case, just counts up to the electrons number. so 3
        //we did -1 and that meant it was in the index (if we had 5 elements, 4 would be the index), doesnt make enough rings or electrons. why??
        //thought i -1 would fix this, due to i counting to 4 (0,1,2,3) when theres only 3 electrons (1,2,3). but this still doesnt work

        for (int i = 0; i < shells; i++)
        {
            //createring(i + 1); //this is more practical but with the way we are programming this i dont think it will help with trying to make the code more readable.

            if (i == 0)
            {
                createring(1);

                int points = element.electronsS1;
                double radius = innerRadius * i;

                double slice = 2 * Math.PI / points;

                //for (int j = 1; i < element.electronsS1; j++)
                //{

                    //double angle = slice * i;
                    //int newX = (int)(centre.x + radius * Math.Cos(angle));
                    //int newY = (int)(centre.y + radius * Math.Sin(angle));

                    //Vector3 p = new Vector3 (newX, newY, 0);

                    //GameObject electron = Instantiate(electronstospawn, p + spawnerspinning.transform.position, Quaternion.identity, spawnerspinning.transform);










                    //    ////we have centre 
                    //    ////we want to use y degrees
                    //    //electronRadius = innerRadius * i;
                    //    //tempangle = 360/element.electronsS1;

                    //    //float x = (electronRadius * Math.Cos(tempangle) + centre);
                    //    //float y = (electronRadius * Math.Cos(tempangle) + centre);

                    //    //electronVector = new Vector3(x, y, 0);

                    //    //GameObject electron = Instantiate(electronstospawn, electronVector + spawnerspinning.transform.position, Quaternion.identity, spawnerspinning.transform);
                //}
            }




            else if (i == 1)

                createring(2);

            else if (i == 2)

                createring(3);

            else if (i == 3)

                createring(4);

            else if (i == 4)

                createring(5);

            else if (i == 5)

                createring(6);

            else if (i == 6)

                createring(7);




        }


//        //this is gonna be a for loop nightmare do it in the create ring thing 
//        for (int i = 1; i < TotalElectrons; i++)
//        {

//            //counts up the total electrons 
            
//            //find the radius of the ring 
//            Debug.Log("total electron loop entered");

//            if (i  <= 2)
//            {
//                electronAngleAsFloat = 180;
//                float DistanceOfRing = (innerRadius * i);


//                for (int j = 1; j <= element.electronsS1; j++) //just see how the electron  elements are stored 
//                {

//                     //know how far the electron is //we need to do this with vectors 
                   
              

//                    if (j == 2)

//                    {
//                        DistanceOfRing = -DistanceOfRing; //so rather than changing the angle ,of the elctron itself (which only roatates the electron, not its position, you have to change the distance of ring and electron position vector.
//                    }

//                    //need to use the vector, but we work out said vector with an angle. think of it as a clock. 

//                    electronRotation = Quaternion.Euler(electronAngleAsFloat, 0.0f, 0.0f);
//                    electronVector = new Vector3(DistanceOfRing, 0.0f, 0.0f);


//                    GameObject electron = Instantiate(electronstospawn, electronVector + spawnerspinning.transform.position, electronRotation, spawnerspinning.transform);

//                }
//;

//                if (i > 2 && i <= 8)
//                {

//                }






//                //now we work out the angle using segments somehow.
//                //make custom class
//                //make a vector between two points which is direction
//                //find the position of the segments we are at 


//                //could we simply use the angle in the ring function and then the distance that we work out depending on the specific radius index of the ring. 

//                //research how to make a custom class, will probably be similar to the element clas thingwe made with andrei.



//                //maybe if we generater electron position with the ring

//                //we now have the circumference of the first ring




//                // electronPosition(i) = distance


//            }




//            i++;

//        }




//        //for (int i = 0; i < TotalElectrons; i++)

//        //{

//        //    electronVector = electronPosition[i];

//        //    GameObject electron = Instantiate(electronstospawn, electronVector, Quaternion.identity, spawnerspinning.transform);
//        //    //call electron formula thing here for the electron vector position and the angle. will probably have to dowhat we did with element
//        //}
    }

    public void createring(int ringIndex)

    {
        //Quaternion rot = transform.rotation * Quaternion.AngleAxis(90, Vector3.down); did this to try and rotat it, now try and change the ring directly through the rotat3dobj script -CORRECTION JUSGT CHANGE THE ROTATION OF THE ELECTRON SPAWNER IN THE INSPECTOR
        ring = Instantiate(ringstospawn, spawnerspinning.transform.position, transform.rotation); //sets ring variable to a new game object. name in this case for the minute is just nucleus. so therefore "nucleus ring". this allows us to know which ring is associated with what object in the hierarchy


        ring.name = "Ring" + (ringIndex);
        ring.transform.parent = spawnerspinning.transform; //parents the ring to the nucleus/object

        //resets the position of the rings no matter where the nucleus is in the enviroment to zero to prevent any issues
        ring.transform.localScale = Vector3.one; //this resets the scale
        ring.transform.localPosition = Vector3.zero; //resets the position so that it starts at the zero (or the centre of) where ever the planet is positioned. ring is in the same position as the object
        ring.transform.localRotation = Quaternion.identity; //quaternion represents the rotation of the object. ensures rings are in the same rotation as the nucleus

        ringMF = ring.AddComponent<MeshFilter>(); //take ring and add a component, returning the same component, allowing us to add the mesh filter and assign at the same time 
        ringMesh = ringMF.mesh; //rings mesh is equal to the meshfilters mesh
        ringMR = ring.AddComponent<MeshRenderer>(); //this also happens for the mesh renderer
        ringMR.material = ringMat; //makes sure the mesh renderer is set the ring material that assigned in the inspector


        //build ring mesh
        //rewatch the video and comment


        //create the arrays that store our vertices, triangles and uv co-ordinates
        Vector3[] vertices = new Vector3[(segments + 1) * 2 * 2]; //vector 3 array (holds x,y,z points) equal to a new array which has a size of the number of segemnts we have +1 (as the very starting point of the ring will also have to double up as the end position as we dont want them to be the same uv co-ordinates). we multiply by two as we need a vertex at the inner radius and outer final thickness and multiple by two again as we need vertices at the top of the ring and at the bottom of the ring.

        int[] triangles = new int[segments * 6 * 2]; //integer array holds triangles -basically every segment is a quad in our mesh. *2 again as top and bottom

        Vector2[] uv = new Vector2[(segments + 1) * 2 * 2]; //vector 2 array (U,V). same number of points as the verticies as cause every vertex needs a UV number assigned to it  

        int halfway = (segments + 1) * 2; //helper variable, as we are doing the top side and the bottom side, we are doubling the number of vertices we need. verticy 0 is going to be the first vertex of the top side and then halfway through the huge away, the frist vertex of the bottom side. halfway integer is a handy ofset.   

        for (int i = 0; i < segments + 1; i++) //loop through each segment and create quads. segments plus 1 as we are building out the final edge of vertices. 
        {
            progress = (float)i / (float)segments; //determine how far we are along orbiting around the nucleus
            angle = Mathf.Deg2Rad * progress * 360; //find the angle we currently are on the circle. Deg2Rad (is a constant number) * progress * 360. progress * 360 is how much progress we have made in degrees converted to radions. 
            float x = Mathf.Sin(angle); //we can then use this to work out x and z positions of each vertex around the circle by using sin and cos of the circle
            float z = Mathf.Cos(angle);


            //with all this info can now start making all of our vertices

            // vertices[i * 2] = vertices[i * 2 + halfway]  gets us the top side and the bottom side of the vertices. both of these are equal to a new vector 3 (x and z we calculate, y is just 0 as always 0) multiply that by the inner radius and thickness.  
            vertices[i * 2] = vertices[i * 2 + halfway] = new Vector3(x, 0f, z) * (innerRadius * ringIndex + thickness); //this gives us the outside vertices of the ring 

            vertices[i * 2 + 1] = vertices[i * 2 + 1 + halfway] = new Vector3(x, 0f, z) * innerRadius * ringIndex; //on the inside we do the same idea. (plus one is so that we get the odd numbers inbetween). this is just the bottom side. 

            uv[i * 2] = uv[i * 2 + halfway] = new Vector2(progress, 0f); //the points go along the width of the texture that we made, ones gonna be at top, one at bottom.moving horizontally as far as we have progressed, but -f as at the bottom of the texture. 

            uv[i * 2 + 1] = uv[i * 2 + 1 + halfway] = new Vector2(progress, 1f); //for the inner edge of the ring, really just reflecting the vertices. now this is all the way to the top (1f)


            //determining the triangles that make up these quads
            if (i != segments) //if we arent on the final loop, we go ahead and make these triangles. 

            //this is all to do with the quads being made
            {
                triangles[i * 12] = i * 2; //12 as making 4 sets of triangles (2 quads for the top, 2 for the bottom). every loop is going to be an interation of 12 triangle vertices. i * 2 is how its pulling from the vertices array  
                triangles[i * 12 + 1] = triangles[i * 12 + 4] = (i + 1) * 2;
                triangles[i * 12 + 2] = triangles[i * 12 + 3] = i * 2 + 1;
                triangles[i * 12 + 5] = (i + 1) * 2 + 1;
                //what weve done here is getting the two vertices of the edge we created as well as next to to create these sets of 2 triangles. this does it for the top.

                triangles[i * 12 + 6] = i * 2 + halfway;
                triangles[i * 12 + 7] = triangles[i * 12 + 10] = i * 2 + 1;
                triangles[i * 12 + 8] = triangles[i * 12 + 9] = (i + 1) * 2 + halfway;
                triangles[i * 12 + 11] = (i + 1) * 2 + 1 + halfway;
                //this does the same for the bottom

                //notes on word document explaining why they are the order they are. to do with correctly rendering the shape.
            }

        }

        //this ring mesh vertices array is likely the one we are going to need to use. 
        //these here use the information given previously to make the mesh
        ringMesh.vertices = vertices;
        ringMesh.triangles = triangles;
        ringMesh.uv = uv;
        ringMesh.RecalculateNormals(); //normal is perpendicular to the triangle it is trying to form. normals tell which way a vertex is facing. this is useful for lighting



        //research how to work out an vecotor using a known vector, distance and angle.


    }
}








