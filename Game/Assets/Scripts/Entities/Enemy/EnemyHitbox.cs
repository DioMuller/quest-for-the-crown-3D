using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemyHitbox : MonoBehaviour 
{
    public string[] Targets = { "Player", "Enemy" };
    public int AttackPower = 1;

	protected void OnCollisionEnter(Collision other)
	{
        if (Targets.Contains(other.transform.tag))
        {
            var status = other.gameObject.GetComponent<CharacterStatus>();

            OnHit(status);
        }
	}

	public bool OnHit(CharacterStatus other)
	{
		if(other == null) return false;
		
		other.RemoveHealth( AttackPower, transform );
		return true;
	}
}
