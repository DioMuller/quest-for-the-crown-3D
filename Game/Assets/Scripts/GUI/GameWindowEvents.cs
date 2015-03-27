using UnityEngine;
using System.Collections;

public class GameWindowEvents : MonoBehaviour
{
	public int MissionNumber = 1;

	public void GoToCamp()
	{
		PlayerManager.ClearMission(MissionNumber);		
		Application.LoadLevel("Camp");
	}

	public void GoToTitle()
	{
		Application.LoadLevel("Title");
	}
}
