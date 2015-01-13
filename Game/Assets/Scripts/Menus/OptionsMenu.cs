using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class ComboOption
{
	public string Label;
	public string Value;

	public ComboOption(string label, string value)
	{
		this.Label = label;
		this.Value = value;
	}
}

public class OptionsMenu : MonoBehaviour 
{
	#region Public Attributes
	public Text LanguageLabel;
	#endregion Public Attributes

	#region Private Attributes
	private int _selectedLanguage = 0;
	private ComboOption[] _languages;
	#endregion Private Attributes

	/// <summary>
	/// Awake is called on Initialization.
	/// </summary>
	void Awake()
	{
		#region Load Languages
		_languages = new ComboOption[]
		{
			new ComboOption(@"English", "English"),
			new ComboOption(@"Português", "Portuguese")
		};

		var currentSelected = _languages.FirstOrDefault((opt) => opt.Value == GameSettings.Language);

		if( currentSelected == null )
		{
			_selectedLanguage = 0;
		}
		else
		{
			_selectedLanguage = Array.IndexOf(_languages, currentSelected);
		}

		ChangeLanguageLabel();
		#endregion Load Languages
	}

	#region Event Handlers
	public void OnSaveClick()
	{
		#region Language
		if( LanguageLabel != null && _selectedLanguage < _languages.Length )
		{
			GameSettings.Language = _languages[_selectedLanguage].Value;
		}
		#endregion Language

		Application.LoadLevel("Title");
	}

	public void OnCancelClick()
	{
		Application.LoadLevel("Title");
	}

	public void OnLanguageClick()
	{
		_selectedLanguage = (_selectedLanguage + 1) % _languages.Length;
		ChangeLanguageLabel();
	}
	#endregion EventHandlers

	#region Helper Methods
	/// <summary>
	/// Changes the language label.
	/// </summary>
	private void ChangeLanguageLabel()
	{
		if( LanguageLabel != null && _selectedLanguage < _languages.Length )
		{
			LanguageLabel.text = _languages[_selectedLanguage].Label;
		}
	}
	#endregion Helper Methods
}
