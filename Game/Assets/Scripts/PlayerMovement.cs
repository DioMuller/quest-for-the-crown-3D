using System;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using Assets.Libs.Input;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    #region Private Attributes
    /// <summary>
    /// Character Controller component.
    /// </summary>
    private Rigidbody _rigidbody;

    /// <summary>
    /// Last mapped character input.
    /// </summary>
    private CharacterInput _input = new CharacterInput("");
    /// <summary>
    /// Current _input attribute schema.
    /// </summary>
    private string[] _mappedInputSchemas;

	/// <summary>
	/// Can the entity move?
	/// </summary>
	private bool _canMove = true;
    #endregion Private Attributes

    #region Private Properties
    /// <summary>
    /// Gets the current schema Character Input.
    /// </summary>
    CharacterInput Input
    {
        get
        {
            if (_mappedInputSchemas != InputSchemas)
            {
                _input = new CharacterInput(InputSchemas);
                _mappedInputSchemas = InputSchemas;
            }
            return _input;
        }
    }
    #endregion Private Properties

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
    #endregion Public Attributes

    #region MonoBehaviour Methods
    /// <summary>
    /// Initializes MonoBehaviour.
    /// </summary>
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Called once per frame.
    /// </summary>
    void Update()
    {
		if( !_canMove ) return;

        Vector3 movementSpeed = Input.GetMovement() * Speed * Time.deltaTime;
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
