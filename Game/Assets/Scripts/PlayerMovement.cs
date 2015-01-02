using System;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
	#region Private Attributes
	/// <summary>
	/// Character Controller component.
	/// </summary>
	private Rigidbody _rigidbody;
	#endregion Private Attributes

	#region Public Attributes
	/// <summary>
	/// Character speed.
	/// </summary>
	public float Speed = 5.0f;

	/// <summary>
	/// Controller precision/dead zone extra protection test.
	/// </summary>
	public float Precision = 0.01f;
	#endregion Public Attributes

	#region MonoBehaviour Methods
	/// <summary>
	/// Initializes MonoBehaviour.
	/// </summary>
	void Start ()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}
	
	/// <summary>
	/// Called once per frame.
	/// </summary>
	void Update ()
	{
		float mx = Input.GetAxis("Horizontal");
		float mz = Input.GetAxis("Vertical");
		
		Vector3 movementSpeed = new Vector3(mx, 0.0f, mz) * Speed * Time.deltaTime;
		_rigidbody.MovePosition(transform.position + movementSpeed);
	}
	#endregion MonoBehaviour Methods
}
