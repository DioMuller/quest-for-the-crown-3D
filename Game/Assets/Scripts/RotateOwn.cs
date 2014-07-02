using UnityEngine;
using System.Collections;

public class RotateOwn : MonoBehaviour 
{
    public float DegreesPerSecond = 1.0f;

	// Update is called once per frame
	void Update () 
    {
        transform.Rotate(Vector3.right * Time.deltaTime * DegreesPerSecond);
	}
}
