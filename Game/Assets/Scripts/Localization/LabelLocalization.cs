using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class LabelLocalization : MonoBehaviour 
{
	/// <summary>
	/// Use this for initialization.
	/// </summary>
	void Start() 
	{
		var text = GetComponent<Text>();
		text.text = LocalizationManager.GetText(text.text);
	}
}
