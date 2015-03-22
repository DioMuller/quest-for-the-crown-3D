using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

[RequireComponent(typeof(MissionButton))]
public class MissionSelection : MonoBehaviour, ISelectHandler
{
	#region Private Attributes
	/// <summary>
	/// Mission Info.
	/// </summary>
    private MissionButton _mission;
	#endregion Private Attributes

	#region Public Attributes
    public Text MissionTitle;
    public Text MissionPrizes;
    public Text MissionDescription;
    public RawImage MissionThumb;
	#endregion Public Attributes

	// Use this for initialization
	void Start () 
    {
        _mission = GetComponent<MissionButton>();
	}

    public void OnSelect(BaseEventData eventData)
    {
	    MissionTitle.text = LocalizationManager.GetText(_mission.Data.Title);
		MissionDescription.text = LocalizationManager.GetText(_mission.Data.Description);
		MissionPrizes.text = _mission.Data.MoneyPrize + " " + LocalizationManager.GetText("Common.Money");
	    MissionThumb.texture = _mission.Data.Image;
    }

    public void OnClick()
    {
        Application.LoadLevel(_mission.Data.Scene);
    }
}
