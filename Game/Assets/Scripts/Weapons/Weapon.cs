using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour 
{
	private Transform _parent = null;
	private CharacterStatus _parentStatus = null;

	public Transform Parent
	{
		get { return _parent; }
		set
		{
			_parent = value;
			if( _parent != null )
			{
				_parentStatus = _parent.GetComponent<CharacterStatus>();
			}
		}
	}
	public WeaponData Data;

	public void Attack()
	{
		if( _parentStatus && _parentStatus.UseMagic(Data.MagicConsumption) )
		{
			OnAttack();
		}
	}

	public abstract void OnAttack();
	public abstract void OnEquip();
	public abstract void OnUnequip();
}
