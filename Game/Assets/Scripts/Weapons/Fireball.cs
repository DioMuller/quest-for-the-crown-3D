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
            float angle = hb.transform.localRotation.eulerAngles.y;
            float rad = Mathf.Deg2Rad * angle;
            float sin = Mathf.Sin(rad);
            float cos = Mathf.Cos(rad);

            float vx = (cos * hb.Direction.x) + (sin * hb.Direction.z);
            float vz = (cos * hb.Direction.z) - (sin * hb.Direction.x);

            hb.Direction = new Vector3(vx, 0.0f, vz);
        }
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
