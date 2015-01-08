using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AIMovement))]
public class MovementBehaviour : MonoBehaviour 
{
	#region Private Attributes
	private AIMovement _movement;
	#endregion Private Attributes

	#region Properties
	public Vector3 MovementDirection { get; protected set; }
	#endregion Properties

	#region MonoBehaviour Methods
	/// <summary>
	/// Initializes the MovementBehaviour
	/// </summary>
	protected void StartBehaviour()
	{
		_movement = GetComponent<AIMovement>();
		_movement.Register(this);
	}
	
	/// <summary>
	/// Called once per frame.
	/// </summary>
	void Update ()
	{
	}
	#endregion MonoBehaviour Methods
}
