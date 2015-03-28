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
        float velocity = 0.0f;

	    if (_characterStatus.IsInvulnerable) return;
	    if (_characterStatus.IsDead) return;
        if (_cooldown) return;

        if(_targetSelector.CurrentTarget != null )
        {
	        Vector3 targetPos = _targetSelector.CurrentTarget.transform.position;
	        Vector3 entityPos = transform.position;
	        Vector3 difference = (targetPos - entityPos);
			float distance = difference.sqrMagnitude;

			
			if ( distance > ShootingDistance )
	        {
		        _agent.destination = _targetSelector.CurrentTarget.transform.position;
                velocity = 1.0f;
				_running = false;	        
	        }
			else if (distance < PanicDistance || _running)
			{
                velocity = 1.0f;
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
                    if (!Animator.GetBool("IsAttacking") &&  !_characterStatus.IsDead)
                        Animator.SetBool("IsAttacking", true);

	                StartCoroutine(Cooldown());

                    return;
                }
	        }
        }
        else
        {
            _agent.destination = transform.position;
        }

        if( Animator != null )
        {
            if( !Animator.GetBool( "IsAttacking" ) && !_characterStatus.IsDead )
                Animator.SetFloat("Speed", velocity);
        }
	}

    void Fire()
    {
        Fireball.Attack();
    }

	IEnumerator Cooldown()
	{
		if (!_characterStatus.IsDead)
			_cooldown = true;
		else
			Animator.SetBool("IsAttacking", false);

		yield return new WaitForSeconds(CooldownTime);

		Animator.SetBool("IsAttacking", false);
		if (!_characterStatus.IsDead)
		{
			Fire();
			
			_cooldown = false;
		}
	}
	#endregion Methods
}
