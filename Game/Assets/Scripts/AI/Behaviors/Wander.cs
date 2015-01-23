using System.Linq;
using UnityEngine;
using System.Collections;

public class Wander : MovementBehaviour
{
    #region Private Attributes
    /// <summary>
    /// Wander target.
    /// </summary>
    private Vector3 _target;
    #endregion Private Attributes

    #region Public Attributes
    /// <summary>
    /// Wander Jitter.
    /// </summary>
    public float Jitter = 1.25f;
   
    /// <summary>
    /// Wander Distance.
    /// </summary>
    public float WanderDistance = 500.0f;

    /// <summary>
    /// Wander Circle Radius.
    /// </summary>
    public float WanderRadius = 150.0f;
    #endregion Public Attributes

    #region Methods
    /// <summary>
    /// Initializes the MonoBehaviour
    /// </summary>
    protected override void StartBehaviour()
    {
        _target = Vector3.zero;
        base.StartBehaviour();
    }

    /// <summary>
    /// Returns the direction.
    /// </summary>
	public override Vector3? GetDirection()
	{
        float jitterThisTimeSlice = Jitter * Time.deltaTime * 0.0009f;
        Vector3 temp = new Vector3(Random.Range(-1.0f, 1.0f) * jitterThisTimeSlice, 0,
                                   Random.Range(-1.0f, 1.0f) * jitterThisTimeSlice);

        _target += temp;

        _target.Normalize();

        _target *= WanderRadius;

        var direction = Vector3.back.RotateY(transform.eulerAngles.y);

        Vector3 position = new Vector3(transform.position.x, 0.0f, transform.position.z);
        position += (direction * WanderDistance);
        position += _target;

        var newPos = position - transform.position;

        newPos.Normalize();
        return newPos;
	}
	#endregion Methods
}
