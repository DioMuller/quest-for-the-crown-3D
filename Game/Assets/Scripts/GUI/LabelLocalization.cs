using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class LabelLocalization : MonoBehaviour 
{
    private Text _text;

    /// <summary>
    /// First initialization.
    /// </summary>
    void Awake()
    {
        _text = GetComponent<Text>();
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
        print("Getting : " + key);
        if (_text == null) return;

        var label = LocalizationManager.GetText(key);

        if (label != null)
            _text.text = label;
        else
            _text.text = key;
    }
}