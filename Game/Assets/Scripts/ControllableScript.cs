using UnityEngine;
using System.Collections;

public class ControllableScript : MonoBehaviour 
{
	public float Speed = 10;

	#region MonoBehaviour Methods
	/// <summary>
	/// Behavior initialization.
	/// </summary>
	void Start () 
	{
	
	}
	
	/// <summary>
	/// Called every frame.
	/// </summary>
	void Update () 
	{
		Vector2 axis = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
		axis.Normalize();
		axis *= Speed * Time.deltaTime;

		transform.position += new Vector3 (axis.x, 0, axis.y);
	}
	#endregion MonoBehaviour Methods
}
