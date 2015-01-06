using System;
using System.Globalization;
using System.Resources;
using UnityEngine;
using System.Collections;

public class DialogAction : MonoBehaviour
{
    #region Private Attributes
    private LocalizationData _dialog;
    #endregion Private Attributes

    #region Public Attributes
    /// <summary>
	/// Dialog name/index on the DialogText Resource file.
	/// </summary>
	public string DialogKey;
	#endregion Public Attributes

	#region MonoBehaviour Methods
	/// <summary>
	/// Initializes MonoBehaviour.
	/// </summary>
	void Start()
	{
		_dialog = LocalizationManager.Instance.DialogLocalization;
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
			try
			{
                if (_dialog != null)
                {
					MessageBox.Instance.ShowMessage(_dialog.GetEntry(DialogKey));
                }
			}
			catch (Exception ex)
			{
				Debug.LogWarning(ex.Message);
			}
		}
	}

	/// <summary>
	/// Called when any objects exits collision with this.
	/// </summary>
	/// <param name="other"></param>
	void OnTriggerExit(Collider other) 
	{
		MessageBox.Instance.Hide();
	}
	#endregion MonoBehaviour Methods
}
