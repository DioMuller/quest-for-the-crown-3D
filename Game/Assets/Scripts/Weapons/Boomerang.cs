using UnityEngine;
using System.Collections;
using System;

//[RequireComponent(typeof(CameraTrack))]
public class Boomerang : Weapon 
{
    /// <summary>
    /// Player camera info.
    /// </summary>
    CameraTrack _cameraTrack;
    PlayerMovement _playerController;

    BoomerangHitbox _hitbox;

    /// <summary>
    /// Raises the attack event.
    /// </summary>
    public override void OnAttack(WeaponHitbox hitbox)
	{
        if (_cameraTrack == null || _playerController == null)
        {
            _playerController = Parent.GetComponent<PlayerMovement>();
            _cameraTrack = Parent.GetComponent<CameraTrack>();
        }

        _hitbox = hitbox as BoomerangHitbox;
        _hitbox.StartFlight(_cameraTrack, _playerController);
    }

    #region MonoBehaviour Methods
    /// <summary>
    /// Initializes MonoBehaviour.
    /// </summary>
    void Start()
    {
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

    public void OnReturn()
    {
        Destroy(_hitbox.gameObject);
        _hitbox = null;
    }

    public void OnHit(Collider collider)
    {
        if( _hitbox != null )
            _hitbox.Return();
    }
}
