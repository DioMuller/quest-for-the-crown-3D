using UnityEngine;
using System.Collections;

public class Fireball : Weapon 
{
	/// <summary>
	/// Raises the attack event.
	/// </summary>
    public override void OnAttack(WeaponHitbox hitbox)
	{
        var hb = hitbox as FireballHitbox;

        if (hb != null)
        {
            hb.Direction = hb.Direction.RotateY(hb.transform.localRotation.eulerAngles.y);
        }
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
        return true;
    }

    /// <summary>
    /// Called when the hitbox is destroyed.
    /// </summary>
    public override void OnHitboxDestroyed()
    {
        
    }
}
