using System;
using UnityEngine;
using System.Collections;

enum WalkingState
{
	Idle = 0,
	Walking = 1,
	Jogging = 2,
	Running = 3
}

[RequireComponent(typeof(CharacterController))]
public class Controller : MonoBehaviour
{
	private CharacterController _controller;
	private float _timeSinceWalk = 0.0f;
	private WalkingState _walkingState = WalkingState.Idle;

	public float Speed = 5.0f;
	public float JoggingMultiplier = 2f;
	public float SecsToJog = 1.0f;
	public float RunningMultiplier = 3.0f;
	public float Precision = 0.01f;


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


		#region TOCHANGE: Walking Animation
		if (Math.Abs(mx) > Precision || Math.Abs(mz) > Precision)
		{
			float multiplier = 1.0f;

			switch (_walkingState)
			{
				case WalkingState.Idle:
					_walkingState = WalkingState.Walking;
					break;
				case WalkingState.Walking:
					_timeSinceWalk += Time.deltaTime;
					if (_timeSinceWalk > SecsToJog)
					{
						_walkingState = WalkingState.Jogging;
					}
					break;
				case WalkingState.Jogging:
					multiplier = JoggingMultiplier;
					break;
				case WalkingState.Running:
					multiplier = RunningMultiplier;
					break;
				default:
					Debug.Log("Invalid CharacterState.");
					break;
			}
			#endregion TOCHANGE: Walking Animation

			Vector3 movementSpeed = new Vector3(mx, 0.0f, mz) * Speed * Time.deltaTime * multiplier;
			_controller.Move(movementSpeed);
		}
		else
		{
			_walkingState = WalkingState.Idle;
			_timeSinceWalk = 0.0f;
		}
	}
}
