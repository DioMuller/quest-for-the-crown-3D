using UnityEngine;
using System.Collections;

public class WeaponHitbox : MonoBehaviour 
{
	public Weapon ParentWeapon = null;
	
	void OnTriggerEnter(Collider other)
	{
		var status = other.GetComponent<CharacterStatus>();
		
		OnHit(status);
		
		if( ParentWeapon.Data.DestroyOnContact )
		{
			Destroy(gameObject);
		}
	}

	public bool OnHit(CharacterStatus other)
	{
		if(other == null) return false;
		if( ParentWeapon == null ) return false;
		
		other.RemoveHealth( ParentWeapon.Data.AttackPower, ParentWeapon.Parent );
		return true;
	}
}
