using System;
using UnityEngine;
using System.Collections;
using System.Linq;

public class LocalizationManager : MonoBehaviour
{
    #region Singleton
	/// <summary>
	/// Gets the instance.
	/// </summary>
	/// <value>The singleton instance.</value>
	public static LocalizationManager Instance { get; private set; }
    #endregion Singleton

    #region Public Attributes
	/// <summary>
	/// The dialog localization data file.
	/// </summary>
    public LocalizationData[] DialogLocalization = null;
    #endregion Public Attributes

    #region MonoBehaviour Methods
    /// <summary>
    /// Initializes MonoBehaviour.
    /// </summary>
	void Awake() 
    {
        Instance = this;
    }
    #endregion MonoBehaviour Methods

	#region Localization Methods
	public static string GetText(string key)
	{
		if( Instance == null ) return null;

		try
		{
			return Instance.DialogLocalization.FirstOrDefault((l) => l.Language == Application.systemLanguage.ToString()).GetEntry(key);
		}
		catch(Exception e)
		{
			try
			{
				return Instance.DialogLocalization.FirstOrDefault((l) => l.Language == "Default").GetEntry(key);
			}
			catch(Exception ex)
			{
				return null;
			}
		}
	}
	#endregion Localization Methods
}
