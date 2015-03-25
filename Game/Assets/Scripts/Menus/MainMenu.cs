using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	#region Public Attributes
	public string NewGameScene = "";

	public Canvas MenuCanvas = null;
	public Canvas OptionsCanvas = null;
	
	// General
	public ComboBox ComboLanguage;

	// Input
	public ComboBox ComboPlayer1Input;

	#endregion Public Attributes

	void Awake()
	{
		OptionsCanvas.enabled = false;
	}

	#region Event Handlers
	public void OnSaveClick()
	{
		#region Language
		if (ComboLanguage != null)
		{
			GameSettings.Language = ComboLanguage.SelectedValue;
		}
		#endregion Language

		#region Input Methods
		if (ComboPlayer1Input != null)
		{
			string p1Input = ComboPlayer1Input.SelectedValue;
			string p2Input = "";

			GameSettings.Player1Input = p1Input;

			if (!p1Input.Contains("Joy1"))
			{
				p2Input = "Joy1";
			}
			else if (!p1Input.Contains("Keyboard"))
			{
				p2Input = "Keyboard";
			}
			else
			{
				p2Input = "Joy2";
			}

			GameSettings.Player2Input = p2Input;
		}
		#endregion Input Methods

		Application.LoadLevel("Title");
	}

	public void OnCancelClick()
	{
		MenuCanvas.enabled = true;
		OptionsCanvas.enabled = false;

		MenuCanvas.GetComponentInChildren<Button>().Select();
	}
	
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
		MenuCanvas.enabled = false;
		OptionsCanvas.enabled = true;

		OptionsCanvas.GetComponentInChildren<Button>().Select();
	}
	#endregion EventHandlers
}
