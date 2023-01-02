using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AddSpeedToMolecules : MonoBehaviour
{
    public Vector2 v;
    private Vector2 direction;
    private float Speed = 25f;

    // Start is called before the first frame update
    void Start() //goes weird in fixed update, check discord to see website, as i believe the author mentions something about mass
    {
        //direction = RandomUnitVector();

        //transform.position = direction * Speed * Time.deltaTime;

        //we need a random direction, not random speed. 




        v = new Vector2(0, 10);

        v = v.normalized; //this should give me constant velocity
        v *= Speed;
        GetComponent<Rigidbody>().velocity = v * Random.onUnitSphere;

        
        
        
        
        
        
        
        //gradually loses velocity over time
        
    }

    //we now need a sub where thew speed of the object is called whedn its changed. could base it off the enter key. 



    //public Vector2 RandomUnitVector()
    //{
        //float random = Random.Range(0f, 260f);
        //return new Vector2(Mathf.Cos(random), Mathf.Sin(random));
    //}

    private void FixedUpdate()
    {
        

    }
}
