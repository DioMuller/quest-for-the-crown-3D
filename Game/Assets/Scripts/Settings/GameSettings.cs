using UnityEngine;
using System.Collections;

public static class GameSettings
{ 
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
}
