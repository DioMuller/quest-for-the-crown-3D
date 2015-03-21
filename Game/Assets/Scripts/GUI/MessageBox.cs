using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MessageBox : SingletonBehaviour<MessageBox>
{
	#region Private Attributes
	private static Image _image;
	public Text _text;

	public bool _enabled = false;
	public bool _pressed = false;
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

	void FixedUpdate()
	{
		if (_enabled)
		{
			if (Input.GetButton("Submit"))
			{
				if (!_pressed)
				{
					Hide();
				}
			}
			else
			{
				_pressed = false;
			}
		}
	}
	#endregion MonoBehaviour Methods

	#region Methods
	public void ShowMessage(string message)
	{
		_text.text = message;
		_text.enabled = true;
		_image.enabled = true;

		_enabled = _pressed = true;

		Time.timeScale = 0.0f;
	}

	public void Hide()
	{
		_text.enabled = false;
		_image.enabled = false;

		_enabled = _pressed = true;

		Time.timeScale = 1.0f;
	}
	#endregion Methods
}
