//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class NBodySimulation : MonoBehaviour
//{
//    BodyGravity[] bodies;

//    static NBodySimulation instance;

//    void Awake()
//    {

//        bodies = FindObjectsOfType<BodyGravity>();
//        Time.fixedDeltaTime = Universe.physicsTimeStep;
//        Debug.Log("Setting fixedDeltaTime to: " + Universe.physicsTimeStep);
//    }

//    void FixedUpdate()
//    {
//        for (int i = 0; i < bodies.Length; i++)
//        {
//            //Vector3 acceleration = CalculateAcceleration(bodies[i].Position, bodies[i]);
//            Bodies[i].UpdateVelocity(Bodies, Universe.physicsTimeStep);
//            //bodies[i].UpdateVelocity (bodies, Universe.physicsTimeStep);
//        }

//        for (int i = 0; i < bodies.Length; i++)
//        {
//            //Bodies[i].UpdatePosition(Universe.physicsTimeStep);
//        }

//    }

//    //public static Vector3 CalculateAcceleration(Vector3 point, BodyGravity ignoreBody = null)
//    //{
//    //    Vector3 acceleration = Vector3.zero;
//    //    foreach (var body in Instance.bodies)
//    //    {
//    //        if (body != ignoreBody)
//    //        {
//    //            float sqrDst = (body.Position - point).sqrMagnitude;
//    //            Vector3 forceDir = (body.Position - point).normalized;
//    //            acceleration += forceDir * Universe.gravitationalConstant * body.mass / sqrDst;
//    //        }
//    //    }

//    //    return acceleration;
//    //}

//    public static BodyGravity[] Bodies
//    {
//        get
//        {
//            return Instance.bodies;
//        }
//    }

//    static NBodySimulation Instance
//    {
//        get
//        {
//            if (instance == null)
//            {
//                instance = FindObjectOfType<NBodySimulation>();
//            }
//            return instance;
//        }
//    }
//}
