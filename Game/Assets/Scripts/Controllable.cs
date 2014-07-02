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
    /// // The last collision flags returned from controller.Move
    /// </summary>
    private CollisionFlags _collisionFlags;

    /// <summary>
    /// Is the user pressing any keys?
    /// </summary>
    private bool _isMoving = false;

    /// <summary>
    /// When did the user start walking (used for trotting).
    /// </summary>
    private float _walkTimeStart = 0.0f;

    /// <summary>
    /// Character current animation.
    /// </summary>
    private Animation _animation = null;

    /// <summary>
    /// Character controller.
    /// </summary>
    private CharacterController _controller = null;
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
    #endregion  Editor Variables

    #region MonoBehaviour Methods
    /// <summary>
	/// Behavior initialization.
	/// </summary>
	void Awake ()
    {
        // Sets initial direction
        _moveDirection = transform.TransformDirection(Vector3.forward);

        // Loads Character Controller
        _controller = GetComponent<CharacterController>();

	}
	
	/// <summary>
	/// Called every frame.
	/// </summary>
	void Update ()
	{
        // Applies Gravity.
        _controller.SimpleMove(Physics.gravity);

        // Rotation.
        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * RotationSpeed * Time.deltaTime, 0));

        // Move
        _moveSpeed = Input.GetAxis("Vertical") * WalkSpeed;
        Vector3 movement = _moveDirection * _moveSpeed * Time.deltaTime; 
        _controller.Move(movement);
	}
	#endregion MonoBehaviour Methods
}
