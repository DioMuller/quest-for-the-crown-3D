using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Fireball : Weapon 
{
	/// <summary>
	/// Raises the attack event.
	/// </summary>
    public override void OnAttack()
	{
        print("Fireball ATTACK!");
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
}
