using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class AIMovement : MonoBehaviour 
{
	#region Public Attributes
	/// <summary>
	/// Walking Speed.
	/// </summary>
	public float Speed = 5.0f;
	#endregion Public Attributes

	#region Private Attributes
	/// <summary>
	/// The rigidbody.
	/// </summary>
	private Rigidbody _rigidbody;

	/// <summary>
	/// The movement behaviours.
	/// </summary>
	private List<MovementBehaviour> _behaviours;
	#endregion Private Attributes

	#region MonoBehaviour Methods
	/// <summary>
	/// Initializes the MonoBehaviour
	/// </summary>
	void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
		_behaviours = new List<MovementBehaviour>();
	}
	
	/// <summary>
	/// Called once per frame.
	/// </summary>
	void Update ()
	{
		var direction = Vector3.zero;

		foreach( var behaviour in _behaviours )
		{
			var movement = behaviour.MovementDirection;
			movement.y = 0.0f;
			movement.Normalize();
			direction += movement;
		}

		// Y movement should not be possible.
		direction.y = 0.0f;

		// Normalize.
		if( direction.sqrMagnitude > 0.1f )
		{
			direction.Normalize();
			var newPosition = transform.position + direction * Time.deltaTime * Speed;
			transform.LookAt(newPosition);
			_rigidbody.MovePosition(newPosition);
		}
	}
	#endregion MonoBehaviour Methods

	#region Methods
	public void Register(MovementBehaviour behaviour)
	{
		_behaviours.Add(behaviour);
	}
	#endregion Methods
}
