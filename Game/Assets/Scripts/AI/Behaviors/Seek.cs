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

	#region Methods
	/// <summary>
	/// Initializes the MonoBehaviour
	/// </summary>
    protected override void StartBehaviour()
	{
		_targetSelector = GetComponent<TargetSelector>();
        base.StartBehaviour();
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
	#endregion Methods
}
