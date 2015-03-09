using UnityEngine;
using System.Collections;

public class GameWindowEvents : MonoBehaviour 
{
	public void GoToCamp()
	{
		Application.LoadLevel("Camp");
	}

	public void GoToTitle()
	{
		Application.LoadLevel("Title");
	}
}
