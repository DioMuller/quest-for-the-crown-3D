using System.Collections.Generic;
using System.Linq;
using Assets.Code.Libs.Input;
using System;
using UnityEngine;

public class ShowMenu : MonoBehaviour
{
	private List<PlayerMovement> _players = new List<PlayerMovement>();

	#region MonoBehaviour Methods

	void Update()
	{
		if (_players.Count > 0) // So Wont search the list if its empty.
		{
			if (_players.Any(p => p.Input.GetButton("Action")))
			{
				OptionSelection.Instance.OpenMissionSelection();
			}
		}
	}

	/// <summary>
	/// Called when any objects collides with this.
	/// </summary>
	/// <param name="other"></param>
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			_players.Add(other.gameObject.GetComponent<PlayerMovement>());
		}
	}

	/// <summary>
	/// Called when any objects exits collision with this.
	/// </summary>
	/// <param name="other"></param>
	void OnTriggerExit(Collider other) 
	{
		if (other.tag == "Player")
		{
			_players.Remove(other.gameObject.GetComponent<PlayerMovement>());
		}
	}
	#endregion MonoBehaviour Methods
}
