using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class GenerateElectrons : MonoBehaviour
{
  

    //change the z to move the electrons slightly
    //REMEMBER INSPECTOR VARIABLES OVERRIDES THESE DEFAULTS SO MAKE SURE TO ADD ELECTRON POSITION IN INSPECTOR
    //public List<Vector3> electronPosition = new List<Vector3>() { new Vector3(815.1f, -4.5f, 1.8f), new Vector3(814.9f, -4.5f, 1.8f), new Vector3(815.01f, -4.6f, 1.8f), new Vector3(815, -4.6f, 1.8f) };


    public GameObject Pivot; //sets up a game object to be used as a pivot on the spawner spinning. //these first two are set in the inspector. 
    public GameObject spawnerspinning; //this sets up the spawner spinning object 
    public GameObject electronstospawn; //this is going to hold the electron prefab in order to instantiate it. 
    public GameObject shellstospawn; //this is how many shells we are going to need 

    //these are all gameobjects. 

    // GameObject nucleusSphere;


    //NOTE WE CHANGE RADIUS TO 0.01F FROM 0.0995F

    [Range(3, 360)] //allows us to change the number of segments in the inspector
    public int segments = 360; //how many segments the Shell is made up of. the more segments, the smoother/rounder the edge. in general, no need for as many as 360 but as a circle, has to have a minimum of 3 segments otherwise range wont be set and will default to zero leading to issues. you cant have a shape with only 2 lines allowed. but with 3, you make a triangle, which you could say is just a very low poly circle
    public float innerRadius = 0.0095f;  //how far away from the centre of the nucleus the shell start (for higher principle energy levels, increase this).  
    private float thickness = 0.005f; //how wide the Shell will be 
    public Material ShellMat; //allows us to give the shell a texture/material of whatever we want
    public float progress; //float that allows us to track how much of the ring we have created
    public float angle;
    //float electronAngleAsFloat;
    //Quaternion electronRotation;
    //public Quaternion rotationofShell = Quaternion.Euler(110, 0, 0);

    //cached references (so that we can easily access parts of the Shell as they arent technically part of the nucleus)

    GameObject Shell;
    Mesh ShellMesh;
    MeshFilter ShellMF; //component that holds the mesh
    MeshRenderer ShellMR; //not public, so if need to access from somewhere else, make them public or properties that can access them

    Quaternion rotationofShell = Quaternion.Euler(0, 90, 0); //rotates the shell to 90 degrees on the y axis. 

    public void ButtonClick(Element element) //passes in the scriptable object of the element that has been clicked on. 
    {

        int TotalElectrons = element.electronsS1 + element.electronsS2 + element.electronsS3 + element.electronsS4 + element.electronsS5 + element.electronsS6 + element.electronsS7; //each shell summed together to get the total number of electrons
        int shells = element.shells; //get the number of shells
        Vector3 centre = spawnerspinning.transform.position; //the centre is the same place in the game world as the spawner. 
        
       // float electronRadius;

        //i is the index in this case, just counts up to the electrons number. so 3
        //we did -1 and that meant it was in the index (if we had 5 elements, 4 would be the index), doesnt make enough rings or electrons. why??
        //thought i -1 would fix this, due to i counting to 4 (0,1,2,3) when theres only 3 electrons (1,2,3). but this still doesnt work

        for (int i = 0; i < shells; i++) //goes through each shell. 
        {
            //createShell(i + 1); //this is more practical but with the way we are programming this i dont think it will help with trying to make the code more readable.

            if (i == 0)
            {
                spawnerspinning.transform.rotation = Pivot.GetComponent<Transform>().rotation; //sets the pivot of the spawner spinning rotation
                createShell(1); //creates first shell
                createElectrons(element.electronsS1, centre, innerRadius + (thickness/2)); //creates electrons by passing number of electrons in that shell in, the centre point and the radius from the centre.

                //int points = element.electronsS1;
                //double radius = innerRadius * i;

                //double slice = 2 * Math.PI / points;

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




            else if (i == 1) //for rest of the shells, goes through and does the same, generate a ring with a larger radius and spawning the electrons using a wider radius. 
            {
                createShell(2); //passes the shell index in, which acts as the multiplier to the radius of the shell 
                createElectrons(element.electronsS2, centre, innerRadius * 2 + (thickness / 2)); //passes in the number of electrons contained in that shell, the centre point, the inner radius width multiplied by the shell index, plus the thickness / by two to find the centre of the shell. 
            }



            else if (i == 2)
            {
                createShell(3);
                createElectrons(element.electronsS3, centre, innerRadius * 3 + (thickness / 2));
            }



            else if (i == 3)
            {
                createShell(4);
                createElectrons(element.electronsS4, centre, innerRadius * 4 + (thickness / 2));
            }

            else if (i == 4)
            {
                createShell(5);
                createElectrons(element.electronsS5, centre, innerRadius * 5 + (thickness / 2));
            }

            else if (i == 5)
            {
                createShell(6);
                createElectrons(element.electronsS6, centre, innerRadius * 6 + (thickness / 2));
            }

            else if (i == 6)
            {
                createShell(7);
                createElectrons(element.electronsS7, centre, innerRadius * 7 + (thickness / 2));
            }


            

        }


        


//        //this is gonna be a for loop nightmare do it in the create Shell thing 
//        for (int i = 1; i < TotalElectrons; i++)
//        {

//            //counts up the total electrons 
            
//            //find the radius of the Shell 
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
//                        DistanceOfRing = -DistanceOfRing; //so rather than changing the angle ,of the elctron itself (which only roatates the electron, not its position, you have to change the distance of Shell and electron position vector.
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


//                //could we simply use the angle in the Shell function and then the distance that we work out depending on the specific radius index of the Shell. 

//                //research how to make a custom class, will probably be similar to the element clas thingwe made with andrei.



//                //maybe if we generater electron position with the Shell

//                //we now have the circumference of the first Shell




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

    public void createElectrons(int num, Vector3 point, float radius)
    {
        for (int i = 0; i < num; i++) //for each of the electrons
        {
            var radians = 2 * Mathf.PI / num * i; //work out the angle of where the electron should be 

            var vertical = Mathf.Sin(radians); //work out the point on the circle in relation to the radians for vertical and horizontal var. 
            var horizontal = Mathf.Cos(radians);

            //Debug.Log(horizontal + "horitzontal");
            //Debug.Log(vertical + "verticle");

            var spawnDir = new Vector3 (vertical, 0 , horizontal); //saves the spawn direction as a vector. 

            var spawnPos = point + spawnDir * radius; //spawn position is the spawner spinning centre + the direction then * by the radius. 

            

            //instantiate 
            GameObject electron = Instantiate(electronstospawn, spawnPos, Quaternion.identity, spawnerspinning.transform);

            //try fiddle with this and the positions of where the electron are spawned
            
        }


    }


    public void createShell(int ShellIndex)

    {
        Shell = Instantiate(shellstospawn, spawnerspinning.transform.position, transform.rotation); //sets Shell variable to a new game object. this allows us to know which Shell is associated with what object in the hierarchy - in this case it is the spawner spinning object. 


        Shell.name = "Shell" + (ShellIndex); //gives a clear name to the Shell - "Ring 1" for example
        Shell.transform.parent = spawnerspinning.transform; //parents the Shell to the spawnerspinning object

        //resets the position of the rings no matter where the spawner is in the enviroment to zero to prevent any issues
        Shell.transform.localScale = Vector3.one; //this resets the scale
        Shell.transform.localPosition = Vector3.zero; //resets the position so that it starts at the zero (or the centre of) where ever the spawner is positioned. Shell is in the same position as the object
        Shell.transform.localRotation = rotationofShell; //quaternion represents the rotation of the object. ensures rings are in the same rotation as the spawner - this keeps them all the same rotation

        ShellMF = Shell.AddComponent<MeshFilter>(); //take Shell and add a component, returning the same component, allowing us to add the mesh filter and assign at the same time 
        ShellMesh = ShellMF.mesh; //rings mesh is equal to the meshfilters mesh
        ShellMR = Shell.AddComponent<MeshRenderer>(); //this also happens for the mesh renderer
        ShellMR.material = ShellMat; //makes sure the mesh renderer is set to the Shell material (assigned in the inspector)


        //create the arrays that store our vertices, triangles and uv co-ordinates
        Vector3[] vertices = new Vector3[(segments + 1) * 2 * 2]; //vector 3 array (holds x,y,z points) equal to a new array which has a size of the number of segemnts we have +1 (as the very starting point of the Shell will also have to double up as the end position - we dont want them to be the same uv co-ordinates). we multiply by two as we need a vertex at the inner radius and outer final thickness / outer radius and multiple by two again as we need vertices at the top of the Shell and at the bottom of the Shell, so that we can see it from both the top and bottom, preventing back face culling from occuring. 

        int[] triangles = new int[segments * 6 * 2]; //integer array holds triangles - every segment is a quad in our mesh. *2 again as top and bottom /// why is this * 6

        //a quad is made up of two triangles sharing a common edge and is therefore made up of 6 vertex points. for each segment, we are going to need 6 vertex points, and since we need to render the bottom and top of this 'segment', we need two times the number of vertex points, so that we can have a quad on the bottom and on the top at each segment. 

        Vector2[] uv = new Vector2[(segments + 1) * 2 * 2]; //vector 2 array (U,V). same number of points as the vertices array as every vertex needs a UV number assigned to it  

        int halfway = (segments + 1) * 2; //helper variable - as we are doing the top side and the bottom side, we are doubling the number of vertices we need. vertice 0 is going to be the first vertex of the top side and then again halfway through the huge array, being the frist vertex of the bottom side. halfway integer is a handy ofset.   

        for (int i = 0; i < segments + 1; i++) //loop through each segment and create quads. segments plus 1 as we are building out the final edge of vertices. 
        {
            progress = (float)i / (float)segments; //determine how far we are along orbiting around the spawner . when we first start, i is 0, so 0 / 360 = 0. when we get to the end, it will be 360 / 360 = 1, so progressing through these loops from zero to one, nice represention of where we are around the circle. 
            angle = Mathf.Deg2Rad * progress * 360; //how much progress we have made and convert to radians //find the angle we currently are on the circle. Deg2Rad (is a constant number) * progress * 360. progress * 360 is how much progress we have made in degrees converted to radions. 
            float x = Mathf.Sin(angle);  //we can then use this to work out x and z positions of each vertex around the circle by using sin and cos of the angle
            float z = Mathf.Cos(angle); 
            //do x and z as y represents the axis to the north to south pole, and we are gonna assume these shells go around the equator. 


            //with all this info can now start making all of the vertices

            //gets us the top side and the bottom side of the outside vertices. both of these are equal to a new vector3 (x and z we calculate, y is just 0 as always 0) multiply that by the inner radius and thickness.  
            vertices[i * 2] = vertices[i * 2 + halfway] = new Vector3(x, 0f, z) * (innerRadius * ShellIndex + thickness); //this end section gives us the outside vertices of the Shell 

            vertices[i * 2 + 1] = vertices[i * 2 + 1 + halfway] = new Vector3(x, 0f, z) * innerRadius * ShellIndex; //on the inside vertices we do the same. (plus one is so that we get the odd numbers inbetween). this is just the bottom side. dont need thickness only inner radius as this is for the inside vertices. 


            // can now work out our uvs, with the vector2's going along the width of the texture that we created, ones at the top, ones at bottom. 

            //this gives uv values for the top and bottom vertices of the outside of the shell ring
            uv[i * 2] = uv[i * 2 + halfway] = new Vector2(progress, 0f); //moving horizontally as far as we have progressed, but 0f as it will always be at the bottom of the texture. 

            //this gives uv values for the top and bottom vertices of the inside of the shell ring
            uv[i * 2 + 1] = uv[i * 2 + 1 + halfway] = new Vector2(progress, 1f); // reflecting the vertices. now this is done all along the top of the texture (1f)


            //determining the triangles that make up these quads
            if (i != segments) //if not on the final loop, go ahead and make these triangles. 
            //dont do last loop, as on the last loop we are creating vertices for that last edge, but it doesnt have its own quads associated with it - it just finishes the previous quads. 

            //this is all to do with the quads being formed
            {
                triangles[i * 12] = i * 2; //12 as making 4 sets of triangles (2 quads for the top, 2 for the bottom). every loop is going to be an iteration of 12 triangle vertices. i * 2 is how its pulling from the vertices array  
                triangles[i * 12 + 1] = triangles[i * 12 + 4] = (i + 1) * 2;
                triangles[i * 12 + 2] = triangles[i * 12 + 3] = i * 2 + 1;
                triangles[i * 12 + 5] = (i + 1) * 2 + 1;
                //this is getting the two vertices of the edge we created, as well as the next two in order to create these sets of 2 triangle. this does it for the top.

                triangles[i * 12 + 6] = i * 2 + halfway;
                triangles[i * 12 + 7] = triangles[i * 12 + 10] = i * 2 + 1; //on flip side so have to reverse the order of these triangles to prevent back face culling. 
                triangles[i * 12 + 8] = triangles[i * 12 + 9] = (i + 1) * 2 + halfway;
                triangles[i * 12 + 11] = (i + 1) * 2 + 1 + halfway;
                //this does the same for the bottom

                //notes on coursework document explaining why they are the order they are. to do with correctly rendering the shape.
            }

        }

        //this Shell mesh vertices array is the one going to need to use. 
        //these here use the information given previously to make the mesh
        ShellMesh.vertices = vertices;
        ShellMesh.triangles = triangles;
        ShellMesh.uv = uv;
        ShellMesh.RecalculateNormals(); //normal is perpendicular to the triangle it is trying to form. normals tell which way a vertex is facing. this is useful for lighting

    }
}








