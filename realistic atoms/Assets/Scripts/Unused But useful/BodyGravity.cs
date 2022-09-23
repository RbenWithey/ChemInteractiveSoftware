//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[ExecuteInEditMode]
//[RequireComponent(typeof(Rigidbody))]


////newtons law of universal gravitation 


//public class BodyGravity : GravityObject
//{
    
//    public float radius;
//    public float surfaceGravity;
//    public Vector3 initialVelocity;
//    public string bodyName = "Unamed";
//    Transform meshHolder;

//    public Vector3 velocity { get; private set; }
//    public float mass { get; private set; }
//    Rigidbody rb;

//    void Awake()
//    {
//        rb = GetComponent<Rigidbody>(); 
//        rb.mass = mass;
//        velocity = initialVelocity;
//    }

//    public void UpdateVelocity(BodyGravity[] allBodies, float timeStep)
//    {
//        foreach (var otherBody in allBodies)
//        {
//            if (otherBody != this)
//            {
//                float sqrDst = (otherBody.rb.position - rb.position).sqrMagnitude;
//                //Vector3 forceDir = (otherBody.rb.position - rb.position).normalized;
//                //Vector3 force = forceDir * Universe.gravitationalConstant * mass * otherBody.mass / sqrDst;
//                //Vector3 acceleration = force / mass;
//                //velocity += acceleration * timeStep;
//            }
//        }
//    }

//    public void UpdatePosition(float timeStep)
//    {
//        //rb.MovePosition(rb.position + velocity * timeStep);

//    }

//    void OnValidate()
//    {


//        mass = surfaceGravity * radius * radius / Universe.gravitationalConstant;
//        meshHolder = transform;
//        meshHolder.localScale = Vector3.one * radius;
//        gameObject.name = bodyName;
//    }

//    public Rigidbody Rigidbody
//    {
//        get
//        {
//            return rb;
//        }
//    }

//    public Vector3 Position
//    {
//        get
//        {
//            return rb.position;
//        }
//    }

//}
