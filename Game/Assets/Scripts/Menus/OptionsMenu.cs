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
    // General
	public Text LanguageLabel;
    // Controls
    public Text Player1InputLabel;
    public Text Player2InputLabel;
	#endregion Public Attributes

	#region Private Attributes
	private int _selectedLanguage = 0;
	private ComboOption[] _languages;
    private int _selectedControlPlayer1 = 0;
    private ComboOption[] _controlMethodsP1;
    private int _selectedControlPlayer2 = 1;
    private ComboOption[] _controlMethodsP2;
	#endregion Private Attributes

	/// <summary>
	/// Awake is called on Initialization.
	/// </summary>
	void Start()
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
		#endregion Load Inputs

        #region Load Inputs P1
        _controlMethodsP1 = new ComboOption[]
		{
			new ComboOption(LocalizationManager.GetText("Options.Keyboard"), "Keyboard"),
            new ComboOption(LocalizationManager.GetText("Options.Controller"), "Joy1"),
			new ComboOption(LocalizationManager.GetText("Options.KeyboardController"), "Keyboard;Joy1")
		};

        currentSelected = _controlMethodsP1.FirstOrDefault((opt) => opt.Value == GameSettings.Player1Input);

        if (currentSelected == null)
        {
            _selectedControlPlayer1 = 0;
        }
        else
        {
            _selectedControlPlayer1 = Array.IndexOf(_controlMethodsP1, currentSelected);
        }

        ChangeControlPlayer1Label();
        #endregion Load Inputs P1

        #region Load Inputs P2
        LoadPlayer2Options();
        #endregion Load Inputs P2
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

        #region Input Methods
        if (Player1InputLabel != null && _selectedControlPlayer1 < _controlMethodsP1.Length)
        {
            GameSettings.Player1Input = _controlMethodsP1[_selectedControlPlayer1].Value;
        }

        if (Player2InputLabel != null && _selectedControlPlayer2 < _controlMethodsP2.Length)
        {
            GameSettings.Player2Input = _controlMethodsP2[_selectedControlPlayer2].Value;
        }
        #endregion Input Methods

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

	public void OnP1InputClick()
	{
        _selectedControlPlayer1 = (_selectedControlPlayer1 + 1) % _controlMethodsP1.Length;
		ChangeControlPlayer1Label();
        LoadPlayer2Options();
	}

    public void OnP2InputClick()
    {
        _selectedControlPlayer2 = (_selectedControlPlayer2 + 1) % _controlMethodsP2.Length;
        ChangeControlPlayer2Label();
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

    private void ChangeControlPlayer1Label()
    {
        if( Player1InputLabel != null && _selectedControlPlayer1 < _controlMethodsP1.Length )
        {
            Player1InputLabel.text = _controlMethodsP1[_selectedControlPlayer1].Label;
        }
    }

    private void ChangeControlPlayer2Label()
    {
        if (Player2InputLabel != null && _selectedControlPlayer2 < _controlMethodsP2.Length)
        {
            Player2InputLabel.text = _controlMethodsP2[_selectedControlPlayer2].Label;
        }
    }

    private void LoadPlayer2Options()
    {
        var inputsP1 = _controlMethodsP1[_selectedControlPlayer1].Value.Split(';');
        string joy = inputsP1.Contains("Joy1") ? "Joy2" : "Joy1";

        if( !inputsP1.Contains("Keyboard") )
        {
            _controlMethodsP2 = new ComboOption[]
		    {
			    new ComboOption(LocalizationManager.GetText("Options.Keyboard"), "Keyboard"),
                new ComboOption(LocalizationManager.GetText("Options.Controller"), joy),
			    new ComboOption(LocalizationManager.GetText("Options.KeyboardController"), "Keyboard;" + joy)
		    };
        }
        else
        {
            _controlMethodsP2 = new ComboOption[]
		    {
                new ComboOption(LocalizationManager.GetText("Options.Controller"), joy)
		    };
        }

        var currentSelected = _controlMethodsP2.FirstOrDefault((opt) => opt.Value == GameSettings.Player2Input);

        if (currentSelected == null)
        {
            _selectedControlPlayer2 = 0;
        }
        else
        {
            _selectedControlPlayer2 = Array.IndexOf(_controlMethodsP2, currentSelected);
        }

        ChangeControlPlayer2Label();
    }
	#endregion Helper Methods
}
