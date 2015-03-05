using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

[RequireComponent(typeof(MissionButton))]
public class MissionSelection : MonoBehaviour, ISelectHandler
{
    private MissionButton _mission;

    public Text MissionTitle;
    public Text MissionPrizes;
    public Text MissionDescription;
    public Image MissionThumb;

	// Use this for initialization
	void Start () 
    {
        _mission = GetComponent<MissionButton>();
	}

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log("test" + _mission.Data.MissionId);
    }

}
