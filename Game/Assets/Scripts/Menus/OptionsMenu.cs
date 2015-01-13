using UnityEngine;
using System.Collections;

public class OptionsMenu : MonoBehaviour 
{
	public void OnSaveClick()
	{
		Application.LoadLevel("Title");
	}

	public void OnCancelClick()
	{
		Application.LoadLevel("Title");
	}
}
