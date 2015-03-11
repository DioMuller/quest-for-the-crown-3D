using UnityEngine;
using System.Collections;

public class RotationScript : MonoBehaviour 
{
    public float RotationAmount = 1.0f;
	
	// Update is called once per frame
	void Update () 
    {
        transform.Rotate(Vector3.forward, RotationAmount * Time.deltaTime);
	}
}
