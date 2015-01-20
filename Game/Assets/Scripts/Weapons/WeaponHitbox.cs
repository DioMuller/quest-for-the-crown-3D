using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class WeaponHitbox : MonoBehaviour 
{
	public Weapon ParentWeapon = null;

    public string[] Targets = { "Player", "Enemy" };

    public float DestroyTime = 0.0f;

    void Start()
    {
        if( DestroyTime > 0.0f )
            StartCoroutine(DestroyAfterTime());
    }
	
	void OnTriggerEnter(Collider other)
	{
        if (!Targets.Contains(other.tag)) return;

		var status = other.GetComponent<CharacterStatus>();
        
		OnHit(status);
		
		if( ParentWeapon.Data.DestroyOnContact )
		{
			Destroy(gameObject);
		}
	}

    public IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(DestroyTime);
        Destroy(gameObject);
    }

	public bool OnHit(CharacterStatus other)
	{
		if(other == null) return false;
		if( ParentWeapon == null ) return false;
		
		other.RemoveHealth( ParentWeapon.Data.AttackPower, ParentWeapon.Parent );
		return true;
	}
}
