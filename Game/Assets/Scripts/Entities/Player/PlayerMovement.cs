using System;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using Assets.Libs.Input;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class PlayerMovement : MonoBehaviour
{
    #region Private Attributes
    /// <summary>
    /// Character Controller component.
    /// </summary>
    private Rigidbody _rigidbody;

	/// <summary>
	/// Can the entity move?
	/// </summary>
	private bool _canMove = true;
    #endregion Private Attributes

    #region Properties
    /// <summary>
    /// Gets the current schema Character Input.
    /// </summary>
    public CharacterInput Input
    {
        get { return CharacterInput.FromSchemas(InputSchemas); }
    }
    #endregion Properties

    #region Public Attributes
    /// <summary>
    /// Character speed.
    /// </summary>
    public float Speed = 5.0f;

    /// <summary>
    /// Controller precision/dead zone extra protection test.
    /// </summary>
    public float Precision = 0.01f;

    /// <summary>
    /// Input sources prefix used for movement.
    /// </summary>
    public string[] InputSchemas;

	/// <summary>
	/// The max velocity change.
	/// </summary>
	public float MaxVelocityChange;
    #endregion Public Attributes

    #region MonoBehaviour Methods
    /// <summary>
    /// Initializes MonoBehaviour.
    /// </summary>
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
		_rigidbody.freezeRotation = true;
    }

    /// <summary>
    /// Called once per frame.
    /// </summary>
    void FixedUpdate()
    {
		if( !_canMove ) return;

        var movementSpeed = Input.GetMovement() * Speed * Time.fixedDeltaTime;

		var newPos = transform.position + movementSpeed;
        transform.LookAt(newPos);

		_rigidbody.MovePosition(newPos);
    }

    #endregion MonoBehaviour Methods

	#region Methods
	/// <summary>
	/// Blocks the movement.
	/// </summary>
	public void BlockMovement()
	{
		_canMove = false;
	}

	/// <summary>
	/// Unblocks the movement.
	/// </summary>
	public void UnblockMovement()
	{
		_canMove = true;
	}
	#endregion Methods
}
