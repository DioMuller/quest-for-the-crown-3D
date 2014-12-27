using UnityEngine;
using System.Collections;

enum CharacterState
{
	Idle = 0,
	Walking = 1,
	Jogging = 2,
	Running = 3
}

[RequireComponent(typeof(Rigidbody))]
public class Controller : MonoBehaviour
{
	private CharacterController _controller;

	public float speed = 5.0f;

	/// <summary>
	/// Initializes MonoBehaviour.
	/// </summary>
	void Start ()
	{
		_controller = GetComponent<CharacterController>();
	}
	
	/// <summary>
	/// Called once per frame.
	/// </summary>
	void Update ()
	{
		float mx = Input.GetAxis("Horizontal");
		float mz = Input.GetAxis("Vertical");

		_controller.Move(new Vector3(mx, 0.0f, mz) * speed * Time.deltaTime);
	}
}
