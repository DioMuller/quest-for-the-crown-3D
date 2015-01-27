using UnityEngine;
using System.Collections;
using System;

public class Boomerang : Weapon 
{
    public const float FlightDuration = 2f;
    public const float ExtendFlightDuration = 0.5f;

    bool _canControl;
    BoomerangHitbox _hitbox;
    float _flightDuration;
    PlayerMovement _playerController;

    /// <summary>
    /// Raises the attack event.
    /// </summary>
    public override void OnAttack(WeaponHitbox hitbox)
	{
        _canControl = true;
        _hitbox = hitbox as BoomerangHitbox;
        _flightDuration = FlightDuration;

        if (_hitbox != null)
        {
            _hitbox.Direction = _hitbox.Direction.RotateY(_hitbox.transform.localRotation.eulerAngles.y);
        }
	}

    #region MonoBehaviour Methods
    /// <summary>
    /// Initializes MonoBehaviour.
    /// </summary>
    void Start()
    {
        _playerController = Parent.GetComponent<PlayerMovement>();
    }

    public void Update()
    {
        if (_hitbox == null)
            return;

        var target = _playerController.Input.GetTarget();
        if (_canControl && target.magnitude > 0.5)
        {
            if (_flightDuration < 0)
            {
                if (!ParentStatus.UseMagic(Data.MagicConsumption))
                {
                    _canControl = false;
                    return;
                }
                _flightDuration = ExtendFlightDuration;
            }

            _hitbox.Direction = target;
        }
        else if (_flightDuration < 0)
        {
            _hitbox.Direction = Parent.transform.position - _hitbox.transform.position;
            _hitbox.Direction.Normalize();
            return;
        }

        _flightDuration -= Time.deltaTime;
    }

    #endregion MonoBehaviour Methods

    /// <summary>
    /// Called when the attack fails.
    /// </summary>
    public override void OnAttackFail()
    {
        
    }

	/// <summary>
	/// Raises the equip event.
	/// </summary>
    public override void OnEquip()
	{

	}

	/// <summary>
	/// Raises the unequip event.
	/// </summary>
	public override void OnUnequip()
	{

	}

    /// <summary>
    /// Can the weapon attack right now?
    /// </summary>
    /// <returns>If the weapon can attack.</returns>
    public override bool CanAttack()
    {
        return _hitbox == null;
    }

    /// <summary>
    /// Called when the hitbox is destroyed.
    /// </summary>
    public override void OnHitboxDestroyed()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Parent.gameObject)
        {
            Destroy(gameObject);
            _hitbox = null;
        }
    }
}
