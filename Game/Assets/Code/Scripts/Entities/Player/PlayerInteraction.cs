using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Libs.Input;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInteraction : MonoBehaviour 
{
	#region Private Attributes
	/// <summary>
	/// The player controller.
	/// </summary>
	private PlayerMovement _playerController;

	/// <summary>
	/// The nearby dialogs.
	/// </summary>
	private DialogAction _stackedDialog = null;

	/// <summary>
	/// Is there a dialog showing?
	/// </summary>
	private bool _showingDialog = false;

	/// <summary>
	/// Remove item after showing it?
	/// </summary>
	private bool _removeAfterShowing = false;

	private bool _actionPressed = false;
	#endregion Private Attributes

	#region Private Properties
	/// <summary>
	/// Gets the current schema Character Input.
	/// </summary>
	CharacterInput Input
	{
		get { return CharacterInput.FromSchemas(_playerController.InputSchemas); }
	}
	#endregion Private Properties

	#region MonoBehaviour Methods
	/// <summary>
	/// Initializes MonoBehaviour.
	/// </summary>
	void Start()
	{
		_playerController = GetComponent<PlayerMovement>();
	}
	
	/// <summary>
	/// Called once per frame.
	/// </summary>
	void Update()
	{
		if(Input.GetButton("Action") )
		{
			if(_actionPressed) return;
			_actionPressed = true;

			if( _stackedDialog != null )
			{
				_showingDialog = _stackedDialog.NextDialog();

				if( _showingDialog ) _playerController.BlockMovement();
				else
				{
					_playerController.UnblockMovement();

					if( _removeAfterShowing )
					{
						RemoveDialog(_stackedDialog);
					}
				}
			}
		}
		else
		{
			_actionPressed = false;
		}
	}
	#endregion MonoBehaviour Methods

	#region Methods
	/// <summary>
	/// Sets the dialog.
	/// </summary>
	/// <param name="action">Dialog Action to be used.</param>
	public void SetDialog(DialogAction action)
	{
		if( !_showingDialog )
		{
			_stackedDialog = action;
		}
	}

	/// <summary>
	/// Removes the dialog, if it's the active dialog.
	/// </summary>
	/// <param name="action">Dialog Action to be removed.</param>
	public void RemoveDialog(DialogAction action)
	{
		if( action == _stackedDialog )
		{
			if( _showingDialog )
			{
				_removeAfterShowing = true;
			}
			else
			{
				_removeAfterShowing = false;
				_stackedDialog = null;
			}
		}
	}
	#endregion Methods
}
