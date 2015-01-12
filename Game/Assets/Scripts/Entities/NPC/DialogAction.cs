using Assets.Code.Libs.Input;
using System;
using UnityEngine;

public class DialogAction : MonoBehaviour, EventAction
{
    #region Private Attributes
	/// <summary>
	/// The next dialog to be shown.
	/// </summary>
	private int _nextDialog = -1;
    #endregion Private Attributes

    #region Public Attributes
    /// <summary>
	/// Dialog name/index on the DialogText Resource file.
	/// </summary>
	public string[] DialogKeys;
	#endregion Public Attributes

	#region MonoBehaviour Methods
	/// <summary>
	/// Initializes MonoBehaviour.
	/// </summary>
	void Start()
	{
	}
	
	/// <summary>
	/// Called once per frame.
	/// </summary>
	private void Update()
	{

	}

	/// <summary>
	/// Called when any objects collides with this.
	/// </summary>
	/// <param name="other"></param>
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			var interaction = other.GetComponent<PlayerInteraction>();

			if(interaction != null)
			{
				interaction.SetAction(this);
			}			
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
			var interaction = other.GetComponent<PlayerInteraction>();
			
			if(interaction != null)
			{
                interaction.ClearAction(this);
			}			
		}
	}
	#endregion MonoBehaviour Methods

	#region Private Methods
	/// <summary>
	/// Shows the dialog.
	/// </summary>
	private void ShowDialog()
	{
		try
		{
			MessageBox.Instance.ShowMessage(LocalizationManager.GetText(DialogKeys[_nextDialog]));
		}
		catch (Exception ex)
		{
			Debug.LogWarning(ex.Message);
		}
	}

	/// <summary>
	/// Hides the dialog.
	/// </summary>
	private void HideDialog()
	{
		_nextDialog = -1;
		MessageBox.Instance.Hide();
	}
	#endregion Private Methods

	#region Public Methods
	/// <summary>
	/// Shows next dialog, or finishes dialog..
	/// </summary>
	/// <returns><c>true</c>, if there was another dialog, <c>false</c> otherwise.</returns>
	public bool NextDialog()
	{
		_nextDialog++;

		if( _nextDialog < DialogKeys.Length )
		{
			ShowDialog();
			return true;
		}
		else
		{
			HideDialog();
			return false;
		}
	}

    public bool Activate()
    {
        return NextDialog();
    }
    #endregion Methods
}
