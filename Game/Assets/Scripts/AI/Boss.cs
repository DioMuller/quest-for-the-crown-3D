using System.Linq;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TargetSelector))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(CharacterStatus))]
public class Boss : MonoBehaviour
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

	/// <summary>
	/// Current checkpoint to go.
	/// </summary>
	private int _currentOrder = 0;

	/// <summary>
	/// Current checkpoint for the enemy.
	/// </summary>
	private EnemyCheckpoint _currentCheckpoint = null;
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
	/// Projectile to be launched/Weapon.
	/// </summary>
	public Fireball Fireball;
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
		
		#region Found Player
		
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
			#region Follow Path

			if (_currentCheckpoint == null)
				_currentCheckpoint = WaypointManager.GetCheckpoint(_currentOrder);

			if (_currentCheckpoint != null)
			{
				_agent.destination = _currentCheckpoint.Position;

				if ((_currentCheckpoint.Position - transform.position).magnitude < 0.1)
				{
					_currentOrder++;
					_currentCheckpoint = null;
				}
			}
			else
			{
				// If Checkpoint was null, it doesn't exist.
				_currentOrder = 0;
			}

			#endregion Follow Path
        }
		
		#endregion Found Player



		#region Animation
		if (Animator != null)
		{
			Animator.SetFloat("Speed", _agent.speed);
		}
		#endregion Animation
    }

    void Fire()
    {
        Fireball.Attack();
    }

	IEnumerator Cooldown()
	{
		_cooldown = true;
		yield return new WaitForSeconds(CooldownTime);
		_cooldown = false;
	}
	#endregion Methods
}
