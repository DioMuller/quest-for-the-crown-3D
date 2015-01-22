using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AIMovement))]
public abstract class MovementBehaviour : MonoBehaviour 
{
	#region Private Attributes
	private AIMovement _movement;
	#endregion Private Attributes

    #region Public Attributes
    /// <summary>
    /// Behaviour Priority.
    /// </summary>
    public int Priority = 0;

    /// <summary>
    /// Behaviour Weight.
    /// </summary>
    public float Weight = 1.0f;
    #endregion Public Attributes

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
	protected virtual void StartBehaviour()
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
