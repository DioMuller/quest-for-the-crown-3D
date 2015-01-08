using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MessageBox : MonoBehaviour 
{
	#region Properties
	public static MessageBox Instance {get; private set;}
	#endregion Properties

	#region Private Attributes
	private static Image _image;
	public Text _text;
	#endregion Private Attributes

	#region MonoBehaviour Methods
	/// <summary>
	/// Initializes MonoBehaviour.
	/// </summary>
	void Start()
	{
		Instance = this;
		_image = GetComponent<Image>();
		_text = GetComponentInChildren<Text>();
		_text.enabled = false;
		_image.enabled = false;
	}
	#endregion MonoBehaviour Methods

	#region Methods
	public void ShowMessage(string message)
	{
		_text.text = message;
		_text.enabled = true;
		_image.enabled = true;
	}

	public void Hide()
	{
		_text.enabled = false;
		_image.enabled = false;
	}
	#endregion Methods
}
