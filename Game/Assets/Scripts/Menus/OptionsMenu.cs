using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour 
{
	#region Public Attributes
    // General
	public ComboBox ComboLanguage;

    // Input
    public ComboBox ComboPlayer1Input;
    public ComboBox ComboPlayer2Input;

	#endregion Public Attributes

	/// <summary>
	/// Awake is called on Initialization.
	/// </summary>
	void Start()
	{

    }

	#region Event Handlers
	public void OnSaveClick()
	{
		#region Language
        if (ComboLanguage != null)
		{
            GameSettings.Language = ComboLanguage.SelectedValue;
		}
		#endregion Language

        #region Input Methods
        if (ComboPlayer1Input != null)
        {
            GameSettings.Player1Input = ComboPlayer1Input.SelectedValue;
        }

        if (ComboPlayer2Input != null )
        {
            GameSettings.Player2Input = ComboPlayer2Input.SelectedValue;
        }
        #endregion Input Methods

        Application.LoadLevel("Title");
	}

	public void OnCancelClick()
	{
		Application.LoadLevel("Title");
	}
	#endregion EventHandlers
}
