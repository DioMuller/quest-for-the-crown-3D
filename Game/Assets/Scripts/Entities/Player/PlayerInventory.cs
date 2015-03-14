using Assets.Libs.Input;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterStatus))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerInventory : MonoBehaviour
{
	private CharacterInput _input;
	private CharacterStatus _status;
	private bool _itemPressed = false;

	// Use this for initialization
	void Start ()
	{
		_status = GetComponent<CharacterStatus>();
		_input = GetComponent<PlayerMovement>().Input;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (_input.GetButton("UseItem1"))
		{
			if (!_itemPressed)
			{
				_itemPressed = true;
				HealthPotionItem.Use(_status);
				ItemGUI.Instance.UpdateItems();
			}
		}
		else if (_input.GetButton("UseItem2"))
		{
			if (!_itemPressed)
			{
				_itemPressed = true;
				MagicPotionItem.Use(_status);
				ItemGUI.Instance.UpdateItems();
			}
		}
		else
		{
			_itemPressed = false;
		}
	}
}
