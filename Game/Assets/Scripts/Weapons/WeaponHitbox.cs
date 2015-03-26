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

    void OnDestroy()
    {
        if( ParentWeapon != null ) ParentWeapon.OnHitboxDestroyed();
    }
	
	protected void OnTriggerEnter(Collider other)
	{
        if (other == null) return;
        if (ParentWeapon == null) return;
        if (other.transform == ParentWeapon.Parent) return;

        if (Targets.Contains(other.tag))
        {
            var status = other.GetComponent<CharacterStatus>();

            OnHit(status);
        }
		
		if( ParentWeapon == null || ParentWeapon.Data.DestroyOnContact )
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
		
		other.RemoveHealth( ParentWeapon.Data.AttackPower, ParentWeapon.Parent, tag == "Fire" );
		return true;
	}
}
