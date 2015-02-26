using UnityEngine;
using System.Collections;

public static class GameSettings
{
    #region General Options
    public static string Language
	{
		get
		{
			if( !PlayerPrefs.HasKey("Language") ) return Application.systemLanguage.ToString();

			return PlayerPrefs.GetString("Language");
		}
		set
		{
			PlayerPrefs.SetString("Language", value);
		}
    }
    #endregion General Options

    #region Controller Options
    public static string Player1Input
    {
        get
        {
            if (!PlayerPrefs.HasKey("Player1Input")) return "Keyboard;Joy1";

            return PlayerPrefs.GetString("Player1Input");
        }
        set
        {
            PlayerPrefs.SetString("Player1Input", value);
        }
    }

    public static string Player2Input
    {
        get
        {
            if (!PlayerPrefs.HasKey("Player2Input")) return "Joy2";

            return PlayerPrefs.GetString("Player2Input");
        }
        set
        {
            PlayerPrefs.SetString("Player2Input", value);
        }
    }
    #endregion Controller Options

    #region Methods
    public static string GetValueFor(string key)
    {
        if (!PlayerPrefs.HasKey(key)) return null;

        return PlayerPrefs.GetString(key);
    }
    #endregion Methods
}
