using UnityEngine;
using System.Collections;

public class CircularGravity : MonoBehaviour
{

    public Transform nucleusSphere; // Big object
    Vector3 targetDirection;

    public int radius = 5;
    public int forceAmount = 500;
    public float gravity = 0;
    private Rigidbody rb;

    //inc rease gravity 

    private float distance;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    // Use this for initialization
    void Start()
    {
        Physics.gravity = new Vector3(0, gravity, 0);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate() //anything physics needs to be done in fixed update to better run physcis rather than being called every frame
    {

        targetDirection = nucleusSphere.position - transform.position; // Save direction
        distance = targetDirection.magnitude; // Find distance between this object and target object
        targetDirection = targetDirection.normalized; // Normalize target direction vector

        if (distance < radius)
        {
            rb.AddForce(targetDirection * forceAmount * Time.fixedDeltaTime);
        }


    }
}