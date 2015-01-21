using UnityEngine;
using System.Collections;

public class Sword : Weapon 
{
    private bool _canAttack = true;

	/// <summary>
	/// Raises the attack event.
	/// </summary>
    public override void OnAttack(WeaponHitbox hitbox)
	{
        _canAttack = false;
	}

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
        return _canAttack;
    }

    /// <summary>
    /// Called when the hitbox is destroyed.
    /// </summary>
    public override void OnHitboxDestroyed()
    {
        _canAttack = true;
    }
}
