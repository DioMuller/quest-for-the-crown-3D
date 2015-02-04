using System.Linq;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TargetSelector))]
public class Seek : MonoBehaviour
{
	#region Private Attributes
	/// <summary>
	/// Current Target Selector.
	/// </summary>
	private TargetSelector _targetSelector;

    private NavMeshAgent _agent;
	#endregion Private Attributes

	#region Methods
	/// <summary>
	/// Initializes the MonoBehaviour
	/// </summary>
    void Start()
	{
		_targetSelector = GetComponent<TargetSelector>();
        _agent = GetComponent<NavMeshAgent>();
	}

    /// <summary>
    /// Sets the target..
    /// </summary>
	void Update()
	{
        if(_targetSelector.CurrentTarget != null)
        {
            _agent.destination = _targetSelector.CurrentTarget.transform.position;
        }
        else
        {
            _agent.destination = transform.position;
        }
	}
	#endregion Methods
}
