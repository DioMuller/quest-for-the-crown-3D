using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LabelLocalization : MonoBehaviour 
{
    private Text _text;

	public bool Upper = false;

    /// <summary>
    /// First initialization.
    /// </summary>
    void Awake()
    {
        _text = GetComponent<Text>();

        if( _text == null )
        {
            _text = GetComponentInChildren<Text>();
        }

        if (_text == null) throw new System.Exception("Error on LabelLocalization: Component or Children should have Text Component.");
    }

	/// <summary>
	/// Use this for initialization.
	/// </summary>
	void Start() 
	{
        ChangeText(_text.text);
	}

    public void ChangeText(string key)
    {
        if (_text == null) return;

        var label = LocalizationManager.GetText(key);

        if (label != null)
            _text.text = Upper ? label.ToUpper() : label;
        else
            _text.text = Upper ? key.ToUpper() : key;
    }
}
