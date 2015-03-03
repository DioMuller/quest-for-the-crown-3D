using System;
using UnityEngine;
using System.Collections;
using System.Linq;

public class LocalizationManager : SingletonBehaviour<LocalizationManager>
{
    #region Public Attributes
	/// <summary>
	/// The dialog localization data file.
	/// </summary>
    public LocalizationData[] DialogLocalization = null;

	/// <summary>
	/// The default language.
	/// </summary>
	public string DefaultLanguage = "English";
    #endregion Public Attributes

	#region Localization Methods
	public static string GetText(string key)
	{
		if( Instance == null ) return null;

		try
		{
			return Instance.DialogLocalization.FirstOrDefault((l) => l.Language == GameSettings.Language).GetEntry(key);
		}
		catch(Exception e)
		{
			//Debug.Log("Key '" + key + "' not found on language, searching for it on default. " + e.Message);
			try
			{
				return Instance.DialogLocalization.FirstOrDefault((l) => l.Language == Instance.DefaultLanguage).GetEntry(key);
			}
			catch(Exception ex)
			{
                //Debug.Log("Key '" + key + "' not found on default, returning null. " + ex.Message);
				return null;
			}
		}
	}
	#endregion Localization Methods
}
