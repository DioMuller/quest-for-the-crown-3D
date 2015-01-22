using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AIMovement))]
public abstract class MovementBehaviour : MonoBehaviour 
{
	#region Private Attributes
	private AIMovement _movement;
	#endregion Private Attributes

    #region MonoBehaviour Methods
    void Start()
    {
        StartBehaviour();
    }
    #endregion MonoBehaviour Methods

    #region Methods
    /// <summary>
	/// Initializes the MovementBehaviour
	/// </summary>
	protected void StartBehaviour()
	{
		_movement = GetComponent<AIMovement>();
		_movement.Register(this);
	}
	
	/// <summary>
	/// Returns the direction.
	/// </summary>
    public abstract Vector3? GetDirection();
	#endregion Methods
}
