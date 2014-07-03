using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;

#region Character States
public enum CharacterState
{
    Idle = 0,
    Walking = 1,
    Trotting = 2,
    Running = 3
}
#endregion Character States

[RequireComponent(typeof(CharacterController))]
public class Controllable : MonoBehaviour
{
    #region Attributes
    /// <summary>
    /// Movement Direction.
    /// </summary>
    private Vector3 _moveDirection = Vector3.zero;

    /// <summary>
    /// Character movement speed.
    /// </summary>
    private float _moveSpeed = 10.0f;

    /// <summary>
    /// Is the user pressing any keys?
    /// </summary>
    private bool _isMoving = false;

    /// <summary>
    /// When did the user start walking (used for trotting).
    /// </summary>
    private float _walkTimeStart = 0.0f;

    /// <summary>
    /// Character controller.
    /// </summary>
    private CharacterController _controller = null;

    /// <summary>
    /// Character animator.
    /// </summary>
    private Animator _animator = null;
    #endregion Attributes

    #region Editor Variables
    /// <summary>
    /// Character walking speed.
    /// </summary>
    public float WalkSpeed = 2.5f;

    /// <summary>
    /// Character trotting speed.
    /// </summary>
    public float TrotSpeed = 5.0f;

    /// <summary>
    /// Character running speed.
    /// </summary>
    public float RunSpeed = 8.0f;

    /// <summary>
    /// Character rotation speed.
    /// </summary>
    public float RotationSpeed = 500.0f;

    /// <summary>
    /// Time for the character to start trotting.
    /// </summary>
    public float TrotAfterSeconds = 3.0f;

    /// <summary>
    /// Player Avatar.
    /// </summary>
    public Transform Avatar = null;
    #endregion  Editor Variables

    #region MonoBehaviour Methods
    /// <summary>
	/// Behavior initialization.
	/// </summary>
	void Awake ()
    {
        // Sets initial direction
        _moveDirection = transform.TransformDirection(Vector3.forward);

        // Loads Character Controller and Animator.
        _controller = GetComponent<CharacterController>();
        _animator = Avatar.GetComponent<Animator>();
	}
	
	/// <summary>
	/// Called every frame.
	/// </summary>
	void Update ()
	{
        // Applies Gravity.
        _controller.SimpleMove(Physics.gravity);

        // Move
        _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

        if( _moveDirection != Vector3.zero )
        {
            _moveDirection.Normalize();
        }

        _moveSpeed = Time.deltaTime * WalkSpeed;
        
        Vector3 movement = _moveDirection * _moveSpeed; 
        _controller.Move(movement);

        if (_animator != null)
        {
            _animator.SetFloat("Speed", _moveSpeed);
            float dir = Vector2.Angle(Vector2.up, new Vector2(_moveDirection.x, _moveDirection.z));
            //_animator.SetFloat("Direction", dir);
            Avatar.rotation = Quaternion.Euler(0.0f, dir, 0.0f);
        }
	}
	#endregion MonoBehaviour Methods
}
