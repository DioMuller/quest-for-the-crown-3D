using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MissionButton : MonoBehaviour
{
    #region Private Attributes
    private Text _label;
    #endregion Private Attributes

    #region Public Attributes
    /// <summary>
    /// Mission Data
    /// </summary>
    public MissionData Data;
    #endregion Public Attributes

    #region MonoBehaviour Methods
    // Use this for initialization
	void Start () 
    {
        _label = GetComponentInChildren<Text>();

        UpdateData();
	}
    #endregion MonoBehaviour Methods

    #region Public Methods
    public void UpdateData()
    {
        if( Data != null )
        {
            _label.text = Data.MissionId.ToString("00") + " " + LocalizationManager.GetText(Data.Title);
        }
    }
    #endregion Public Methods
}
