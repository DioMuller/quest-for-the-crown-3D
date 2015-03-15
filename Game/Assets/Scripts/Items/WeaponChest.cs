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
}
