using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemyHitbox : MonoBehaviour 
{
    public string[] Targets = { "Player", "Enemy" };
    public int AttackPower = 1;
	public Animator Animator;
	public string FlagName = "IsAttacking";
	public string AttackState = "Attacking";

	void Update()
	{
		if (Animator != null)
		{
			// Once transition has begun, reset the bool
			if (Animator.GetNextAnimatorStateInfo(0).IsName(AttackState))
			{
				Animator.SetBool(FlagName, false);
			}
		}
	}

	protected void OnCollisionEnter(Collision other)
	{
        if (Targets.Contains(other.transform.tag))
        {
            var status = other.gameObject.GetComponent<CharacterStatus>();

            OnHit(status);

	        if (Animator != null)
	        {
		        Animator.SetBool(FlagName, true);
	        }
        }
	}

	public bool OnHit(CharacterStatus other)
	{
		if(other == null) return false;
		
		other.RemoveHealth( AttackPower, transform );
		return true;
	}
}
