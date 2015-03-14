using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
    public string NewGameScene = "";

	public void OnNewGameClick()
	{
		PlayerManager.ResetGame();
        Application.LoadLevel(NewGameScene);
	}

	public void LoadGameClick()
	{
	}

	public void OptionsClick()
	{
		Application.LoadLevel("Options");
	}
}
