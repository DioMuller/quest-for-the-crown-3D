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
    public float Jitter;
   
    /// <summary>
    /// Wander Distance.
    /// </summary>
    public float WanderDistance;

    /// <summary>
    /// Wander Circle Radius.
    /// </summary>
    public float WanderRadius;
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
        float jitterThisTimeSlice = Jitter * Time.deltaTime * 0.009f;
        Vector3 temp = new Vector3(Random.Range(-1.0f, 1.0f) * jitterThisTimeSlice, 0,
                                   Random.Range(-1.0f, 1.0f) * jitterThisTimeSlice);

        _target += temp;

        _target.Normalize();

        _target *= WanderRadius;

        var direction = Vector3.back.RotateY(transform.eulerAngles.y);

        Vector3 position = transform.position;
        position += (direction * WanderDistance);
        position += _target;

        return position - transform.position;
	}
	#endregion Methods
}
