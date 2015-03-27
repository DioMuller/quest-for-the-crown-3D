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

	// Options Menu
	public GameObject MainPanel;
	public GameObject PlayersPanel;

	#endregion Public Attributes

	void Awake()
	{
		OptionsCanvas.enabled = false;
		PlayersPanel.SetActive(false);
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
		MainPanel.SetActive(false);
		PlayersPanel.SetActive(true);

		PlayersPanel.GetComponentInChildren<Button>().Select();
	}

    public void OnBackPlayerClick()
    {
        MainPanel.SetActive(true);
        PlayersPanel.SetActive(false);

        MainPanel.GetComponentInChildren<Button>().Select();
    }

	public void OnSinglePlayerClick()
	{
		PlayerManager.ResetGame();
		Application.LoadLevel(NewGameScene);
	}

	public void OnMultiplayerClick()
	{
		PlayerManager.ResetGame(2);
		Application.LoadLevel(NewGameScene);
	}

    public void OnDemoModeClick()
    {
        PlayerManager.DemoMode(1);
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

    public void QuitClick()
    {
        Application.Quit();
    }
	#endregion EventHandlers
}
