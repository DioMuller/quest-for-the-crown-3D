using System;
using System.Globalization;
using System.Resources;
using UnityEngine;
using System.Collections;

public class DialogBox : MonoBehaviour 
{
	#region Private Attributes

    private DialogData _dialog;
	#endregion Private Attributes

	#region Public Attributes
	/// <summary>
	/// Dialog name/index on the DialogText Resource file.
	/// </summary>
	public string DialogName;
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
			try
			{
                if (_dialog != null)
                {
                    Debug.Log(_dialog.Entries.Length);
                    Debug.Log("Dialog: " + _dialog.GetEntry("TestDialog")); //_dialogManager.GetString(DialogName));
                }
			}
			catch (Exception)
			{
				Debug.LogWarning("Error: Could not find dialog '" + DialogName + "'");
			}
		}
	}

	#endregion MonoBehaviour Methods
}
