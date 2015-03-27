using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Code.Libs.Input;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ShowMenu : MonoBehaviour
{
	private List<PlayerMovement> _players = new List<PlayerMovement>();

    public GameObject HelperText = null;

	private bool _buttonPressed = false;

	#region MonoBehaviour Methods

    void Start()
    {
        HelperText.SetActive(false);
    }

	void Update()
	{
		if (_players.Count > 0) // So Wont search the list if its empty.
		{
			if (_players.Any(p => p.Input.GetButton("Action")))
			{
				if (!_buttonPressed)
				{
					_buttonPressed = true;
					OptionSelection.Instance.OpenMissionSelection();
					OptionSelection.Instance.GetComponentInChildren<Button>().Select();

					_players.Clear();
					HelperText.SetActive(false);
				}
			}
			else
			{
				_buttonPressed = false;
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
            HelperText.SetActive(true);
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
            HelperText.SetActive(_players.Count > 0);
		}
	}
	#endregion MonoBehaviour Methods
}
