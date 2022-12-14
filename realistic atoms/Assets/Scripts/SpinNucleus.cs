using UnityEngine;
using System.Collections;

/// <summary>
/// Spin the object at a specified speed
/// </summary>
public class SpinNucleus : MonoBehaviour
{

	public bool spin;
	public bool spinParent;
	public float speed = 10f;

	
	public bool clockwise = true;
	public float direction = 1f;
	public float directionChangeSpeed = 2f;

	// Update is called once per frame
	void Update()
	{
		if (direction < 1f)
		{
			direction += Time.deltaTime / (directionChangeSpeed / 2);
		}

		if (spin)
		{
			if (clockwise)
			{
				if (spinParent)
					transform.parent.transform.Rotate(Vector3.right, (speed * direction) * Time.deltaTime);
				else
					transform.Rotate(Vector3.right, (speed * direction) * Time.deltaTime);
			}
			else
			{
				if (spinParent)
					transform.parent.transform.Rotate(-Vector3.right, (speed * direction) * Time.deltaTime);
				else
					transform.Rotate(-Vector3.right, (speed * direction) * Time.deltaTime);
			}
		}
	}
}