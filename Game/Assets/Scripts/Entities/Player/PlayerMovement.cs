using System;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using Assets.Libs.Input;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerMovement : MonoBehaviour
{
    #region Private Attributes
    /// <summary>
    /// Character Controller component.
    /// </summary>
    private Rigidbody _rigidbody;

	/// <summary>
	/// The collider component.
	/// </summary>
	//private CapsuleCollider _collider;

	/// <summary>
	/// Can the entity move?
	/// </summary>
	private bool _canMove = true;

	/// <summary>
	/// The terrain collider.
	/// </summary>
	public TerrainCollider _groundCollider;
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

	public float SlopeLimit = 30.0f;
    #endregion Public Attributes

    #region MonoBehaviour Methods
    /// <summary>
    /// Initializes MonoBehaviour.
    /// </summary>
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
		//_collider = GetComponent<CapsuleCollider>();
		_groundCollider = (TerrainCollider) GameObject.FindObjectOfType(typeof(TerrainCollider));
    }

    /// <summary>
    /// Called once per frame.
    /// </summary>
    void FixedUpdate()
    {
		if( !_canMove ) return;

		#region New Position
		var inputValue = Input.GetMovement();
		inputValue.Normalize();
        var movementSpeed = inputValue * Speed * Time.fixedDeltaTime;

		var newPos = transform.position + movementSpeed;
        transform.LookAt(newPos);
		#endregion New Position

		#region Slope Detection
		bool canMoveSlope = true;
		if( _groundCollider != null )
		{
			RaycastHit hit = new RaycastHit();
			var ray = new Ray(transform.position, Vector3.down);

			if( _groundCollider.Raycast(ray, out hit, 10) )
			{
				var slope = hit.normal;

				var rotation = Quaternion.FromToRotation(transform.up, slope) * transform.rotation;
				var euler = rotation.eulerAngles;

				var eulerX = Mathf.Abs(euler.x);
				var eulerZ = Mathf.Abs(euler.z);

				if( eulerX > 180 ) eulerX = 360 - eulerX;
				if( eulerZ > 180 ) eulerZ = 360 - eulerZ;

				if( !( eulerX < SlopeLimit &&  eulerZ < SlopeLimit ) )
				{
					canMoveSlope = false;
				}
			}
		}
		#endregion Slope Detection

		if( canMoveSlope )
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
