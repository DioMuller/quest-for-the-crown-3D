using System.Linq;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TargetSelector))]
public class Seek : MovementBehaviour
{
	#region Private Attributes
	/// <summary>
	/// Current Target Selector.
	/// </summary>
	private TargetSelector _targetSelector;
	#endregion Private Attributes

	#region MonoBehaviour Methods
	/// <summary>
	/// Initializes the MonoBehaviour
	/// </summary>
	void Start ()
	{
		_targetSelector = GetComponent<TargetSelector>();
        StartBehaviour();
	}

    /// <summary>
    /// Returns the direction.
    /// </summary>
	public override Vector3? GetDirection()
	{
		if (_targetSelector.CurrentTarget != null)
		{
			var direction = (_targetSelector.CurrentTarget.transform.position - transform.position);

			return direction;
		}

        return null;
	}
	#endregion MonoBehaviour Methods
}
