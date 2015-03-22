using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class WeaponChest : MonoBehaviour
{
	public Weapons WeaponToUnlock;
	public GameObject ObjectiveObject;

	private bool _open = false;
	private List<PlayerMovement> _players = new List<PlayerMovement>();

	void Update()
	{
		if (_open) return;

		foreach (var player in _players)
		{
			if (player.Input.GetButton("Action"))
			{
				_open = true;
				MessageBox.Instance.ShowMessage(GetMessage());
				PlayerManager.ObtainWeapon(WeaponToUnlock);
				Destroy(ObjectiveObject);				
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			_players.Add(other.GetComponent<PlayerMovement>());
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			_players.Remove(other.GetComponent<PlayerMovement>());
		}
	}

	string GetMessage()
	{
		if (PlayerManager.IsWeaponActive(WeaponToUnlock)) return "ItemGet.Already";

		switch (WeaponToUnlock)
		{
				case Weapons.Boomerang:
					return "ItemGet.Boomerang";
				case Weapons.Bow:
					return "ItemGet.Bow";
				case Weapons.Fireball:
					return "ItemGet.Fireball";
				case Weapons.Sword:
					return "ItemGet.Sword";
				default:
					return "ItemGet.Unknown";
		}
	}
}
