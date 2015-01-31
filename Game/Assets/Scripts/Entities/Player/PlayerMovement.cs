using System;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using Assets.Libs.Input;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CameraTrack))]
public class PlayerMovement : MonoBehaviour
{
    #region Private Attributes
    /// <summary>
    /// Character Controller component.
    /// </summary>
    private Rigidbody _rigidbody;

    /// <summary>
    /// Player camera info.
    /// </summary>
    private CameraTrack _cameraTrack;

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

	public float SlopeLimit = 15.0f;
    #endregion Public Attributes

    #region MonoBehaviour Methods
    /// <summary>
    /// Initializes MonoBehaviour.
    /// </summary>
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _cameraTrack = GetComponent<CameraTrack>();
    }

    /// <summary>
    /// Called once per frame.
    /// </summary>
    void FixedUpdate()
    {
        #region Aiming / LookAt Position
        var aimValue = Input.GetTarget(_cameraTrack);
		bool aiming = false;

		if (aimValue.sqrMagnitude > 0.1)
		{
			aimValue.Normalize();
			aiming = true;

			var newAim = transform.position + aimValue;
			transform.LookAt(newAim);
		}
		#endregion Aiming / LookAt Position

		#region Movement Position
		if (!_canMove) return;

		#region New Position
		var inputValue = Input.GetMovement();
		inputValue.Normalize();
        var movementSpeed = inputValue * Speed * Time.fixedDeltaTime;

		var newPos = transform.position + movementSpeed;

	    if (!aiming)
	    {
		    transform.LookAt(newPos);
	    }
	    #endregion New Position

        _rigidbody.MovePosition(newPos);
		#endregion Movement Position
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
