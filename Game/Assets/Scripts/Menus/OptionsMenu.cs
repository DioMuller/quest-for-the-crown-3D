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
        if (ComboPlayer1Input != null && ComboPlayer2Input != null)
        {
            string p1Input = ComboPlayer1Input.SelectedValue;
            string p2Input = ComboPlayer2Input.SelectedValue;
        
            GameSettings.Player1Input = p1Input;

            if (p1Input.Contains("Joy1"))
            {
                p2Input = p2Input.Replace("Joy1", "Joy2");
            }

            GameSettings.Player2Input = p2Input;
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
