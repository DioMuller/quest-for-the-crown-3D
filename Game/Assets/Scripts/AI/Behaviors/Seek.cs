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
		StartBehaviour();
		_targetSelector = GetComponent<TargetSelector>();
	}
	
	/// <summary>
	/// Called once per frame.
	/// </summary>
	void Update ()
	{
		if (_targetSelector.CurrentTarget != null)
		{
			var direction = (_targetSelector.CurrentTarget.transform.position - transform.position);

			MovementDirection = direction;
		}
	}
	#endregion MonoBehaviour Methods
}
