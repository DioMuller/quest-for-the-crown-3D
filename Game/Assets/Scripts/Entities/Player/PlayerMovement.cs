using System;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using Assets.Libs.Input;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(CameraTrack))]
[RequireComponent(typeof(CharacterStatus))]
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

    /// <summary>
    /// Character status.
    /// </summary>
    private CharacterStatus _status;

    /// <summary>
    /// Body collider.
    /// </summary>
    private CapsuleCollider _collider;

    /// <summary>
    /// Character Last Position.
    /// </summary>
    private Vector3 _lastPosition;
    #endregion Private Attributes

    #region Properties
    /// <summary>
    /// Gets the current schema Character Input.
    /// </summary>
    public CharacterInput Input
    {
        get { return CharacterInput.FromSchemas(InputSchemas); }
    }

    /// <summary>
    /// Can the player move?
    /// </summary>
    public bool CanMove
    {
        get { return !_status.IsDead && _canMove; }
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

    /// <summary>
    /// Player Slope Limit
    /// </summary>
	public float SlopeLimit = 15.0f;

    /// <summary>
    /// Animator with controller.
    /// </summary>
    public Animator Animator = null;
    #endregion Public Attributes

    #region MonoBehaviour Methods
    /// <summary>
    /// Initializes MonoBehaviour.
    /// </summary>
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _cameraTrack = GetComponent<CameraTrack>();
        _status = GetComponent<CharacterStatus>();
        _collider = GetComponent<CapsuleCollider>();

        _lastPosition = transform.position;
    }

    /// <summary>
    /// Called once per frame.
    /// </summary>
    void FixedUpdate()
    {
        if (!CanMove) return;

        #region Aiming / LookAt Position
        var aimValue = Input.GetTarget(_cameraTrack, gameObject);
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
        var movementSpeed = inputValue * Speed * Time.fixedDeltaTime;
		var newPos = transform.position + movementSpeed;

        if (Animator != null)
        {
            var spd = movementSpeed.sqrMagnitude * 100.0f;
            Animator.SetFloat("Speed", spd);
        }

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
