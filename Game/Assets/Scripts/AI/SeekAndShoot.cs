using System.Linq;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TargetSelector))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(CharacterStatus))]
public class SeekAndShoot : MonoBehaviour
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

	/// <summary>
	/// Is the enemy running?
	/// </summary>
	private bool _running = false;

    /// <summary>
    /// Is the enemy on cooldown?
    /// </summary>
    private bool _cooldown = false;
	#endregion Private Attributes

    #region Public Attributes
    /// <summary>
    /// Entity Animator.
    /// </summary>
    public Animator Animator;

	/// <summary>
	/// Distance for shooting.
	/// </summary>
	public int ShootingDistance = 5;

	/// <summary>
	/// Enemy panic distance, where it'll run.
	/// </summary>
	public int PanicDistance = 3;

	/// <summary>
	/// Cooldown time for fireball.
	/// </summary>
	public float CooldownTime = 2.0f;

    /// <summary>
    /// Projectile to be launched
    /// </summary>
    public GameObject Projectile = null;

    /// <summary>
    /// Projectile launch position
    /// </summary>
    public Transform LaunchPosition = null;
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
        if(_targetSelector.CurrentTarget != null )
        {
	        Vector3 targetPos = _targetSelector.CurrentTarget.transform.position;
	        Vector3 entityPos = transform.position;
	        Vector3 difference = (targetPos - entityPos);
			float distance = difference.sqrMagnitude;

			
			if ( distance > ShootingDistance )
	        {
		        _agent.destination = _targetSelector.CurrentTarget.transform.position;
				_running = false;	        
	        }
			else if (distance < PanicDistance || _running)
			{
				_agent.destination = entityPos - difference;
				_running = true;
			}
	        else if( !_running )
	        {
		        // Lookat and shoot.
				_agent.destination = entityPos;
                transform.LookAt(targetPos);

                if( !_cooldown )
                {
                    Fire();
	                StartCoroutine(Cooldown());
                }
	        }
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

    void Fire()
    {
        Instantiate(Projectile, LaunchPosition.position, transform.rotation);
    }

	IEnumerator Cooldown()
	{
		_cooldown = true;
		yield return new WaitForSeconds(CooldownTime);
		_cooldown = false;
	}
	#endregion Methods
}
