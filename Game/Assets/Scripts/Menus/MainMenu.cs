using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public void OnNewGameClick()
	{
		Application.LoadLevel("PlainsScene");
	}

	public void LoadGameClick()
	{
	}

	public void OptionsClick()
	{
		Application.LoadLevel("Options");
	}
}
