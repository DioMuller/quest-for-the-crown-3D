using System.Linq;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TargetSelector))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(CharacterStatus))]
public class Seek : MonoBehaviour
{
	#region Private Attributes
	/// <summary>
	/// Current Target Selector.
	/// </summary>
	private TargetSelector _targetSelector;

	/// <summary>
	/// Character Status.
	/// </summary>
	private CharacterStatus _characterStatus;

	/// <summary>
	/// NavMesh Agent.
	/// </summary>
    private NavMeshAgent _agent;
	#endregion Private Attributes

    #region Public Attributes
    /// <summary>
    /// Entity Animator.
    /// </summary>
    public Animator Animator;
    #endregion Public Attributes

    #region Methods
    /// <summary>
	/// Initializes the MonoBehaviour
	/// </summary>
    void Start()
	{
		_targetSelector = GetComponent<TargetSelector>();
	    _characterStatus = GetComponent<CharacterStatus>();
        _agent = GetComponent<NavMeshAgent>();
	}

    /// <summary>
    /// Sets the target..
    /// </summary>
	void Update()
    {
	    if (_characterStatus.IsInvulnerable) return;
        if(_targetSelector.CurrentTarget != null)
        {
            _agent.destination = _targetSelector.CurrentTarget.transform.position;
        }
        else
        {
            _agent.destination = transform.position;
        }

        if( Animator != null )
        {
            Animator.SetFloat("Speed", _agent.speed);
        }
	}
	#endregion Methods
}
