using UnityEngine;
using System.Collections;

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
    public LocalizationData DialogLocalization = null;
    #endregion Public Attributes

    #region MonoBehaviour Methods
    /// <summary>
    /// Initializes MonoBehaviour.
    /// </summary>
	void Start () 
    {
        Instance = this;
    }
    #endregion MonoBehaviour Methods
}
