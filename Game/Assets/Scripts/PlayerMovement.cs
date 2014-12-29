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
public class PlayerMovement : MonoBehaviour
{
	#region Private Attributes
	/// <summary>
	/// Character Controller component.
	/// </summary>
	private CharacterController _controller;
	/// <summary>
	/// Time passed since the character started to walk.
	/// </summary>
	private float _timeSinceWalk = 0.0f;
	/// <summary>
	/// Current character walking state.
	/// </summary>
	private WalkingState _walkingState = WalkingState.Idle;
	#endregion Private Attributes

	#region Public Attributes
	/// <summary>
	/// Character speed.
	/// </summary>
	public float Speed = 5.0f;
	/// <summary>
	/// Jogging speed multiplier.
	/// </summary>
	public float JoggingMultiplier = 2f;
	/// <summary>
	/// Seconds it takes for the character to start to jog.
	/// </summary>
	public float SecsToJog = 1.0f;
	/// <summary>
	/// Running speed multiplier.
	/// </summary>
	public float RunningMultiplier = 3.0f;
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
	#endregion MonoBehaviour Methods
}
