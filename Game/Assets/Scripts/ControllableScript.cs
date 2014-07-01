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

#region Animation Properties

[System.Serializable]
public class CharacterAnimationInfo
{
    #region Animation
    /// <summary>
    /// Character Idle animation.
    /// </summary>
    public AnimationClip IdleAnimation;
    /// <summary>
    /// Character Walk animation.
    /// </summary>
    public AnimationClip WalkAnimation;
    /// <summary>
    /// Character Trot animation.
    /// </summary>
    public AnimationClip TrotAnimation;
    /// <summary>
    /// Character Run animation.
    /// </summary>
    public AnimationClip RunAnimation;

    /// <summary>
    /// Character Idle animation speed.
    /// </summary>
    public float IdleMaxAnimationSpeed = 1.0f;
    /// <summary>
    /// Character Walk animation speed.
    /// </summary>
    public float WalkMaxAnimationSpeed = 0.75f;
    /// <summary>
    /// Character Trot animation speed.
    /// </summary>
    public float TrotMaxAnimationSpeed = 1.0f;
    /// <summary>
    /// Character Run animation speed.
    /// </summary>
    public float RunMaxAnimationSpeed = 1.0f;
    #endregion Animation
}
#endregion Animation Properties

#region Movement Properties

[System.Serializable]
public class CharacterMovementInfo
{
    #region Speed and Movement
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
    #endregion Speed and Movement
}
#endregion Movement Properties

[RequireComponent(typeof(CharacterController))]
public class ControllableScript : MonoBehaviour
{
    #region Attributes
    /// <summary>
    /// Movement Direction.
    /// </summary>
    private Vector3 _moveDirection = Vector3.zero;

    /// <summary>
    /// Character movement speed.
    /// </summary>
    private float _moveSpeed = 0.0f;

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
    #endregion Attributes

    #region Editor Variables
    /// <summary>
    /// Character Animation Info.
    /// </summary>
    public CharacterAnimationInfo CharacterAnimation;

    /// <summary>
    /// Character Movement Info.
    /// </summary>
    public CharacterMovementInfo CharacterMovement;    
    #endregion  Editor Variables

    #region MonoBehaviour Methods
    /// <summary>
	/// Behavior initialization.
	/// </summary>
	void Awake ()
    {
        // Sets initial direction
        _moveDirection = transform.TransformDirection(Vector3.forward);

        _animation = GetComponent<Animation>();

        if (_animation == null)
        {
            Debug.Log("The character being controlled does not have animations.");
            return;
        }

        // Turns out animations if any animation is null.
        if ( CharacterAnimation.IdleAnimation == null ||
             CharacterAnimation.WalkAnimation == null ||
             CharacterAnimation.TrotAnimation == null ||
             CharacterAnimation.RunAnimation  == null )
        {
            _animation = null;
            Debug.Log("One or more animations were not set. All animations will be disabled.");
        }
	}
	
	/// <summary>
	/// Called every frame.
	/// </summary>
	void Update () 
	{
		Vector2 axis = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
		axis.Normalize();
		axis *= CharacterMovement.WalkSpeed * Time.deltaTime;

		transform.position += new Vector3 (axis.x, 0, axis.y);
	}
	#endregion MonoBehaviour Methods
}
