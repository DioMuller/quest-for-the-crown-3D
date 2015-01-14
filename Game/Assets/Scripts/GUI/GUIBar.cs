using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class GUIBar : MonoBehaviour 
{
	#region Public Attributes
	/// <summary>
	/// The color of the value bar.
	/// </summary>
	public Color ValueColor = Color.gray;

	public Texture2D Icon = null;
	#endregion Public Attributes

	#region Private Attributes
	/// <summary>
	/// The value image.
	/// </summary>
	private Transform _valueImage;

	/// <summary>
	/// The label text.
	/// </summary>
	private Transform _labelText;

	/// <summary>
	/// The sicon image.
	/// </summary>
	private Transform _iconImage;

	/// <summary>
	/// The value rect transform.
	/// </summary>
	private RectTransform _valueRectTransform;

	/// <summary>
	/// The value sprite renderer.
	/// </summary>
	private Image _valueImageRenderer;

	/// <summary>
	/// The counter label.
	/// </summary>
	private Text _counterLabel;

	/// <summary>
	/// The icon sprite renderer.
	/// </summary>
	private Image _iconImageRenderer;

	/// <summary>
	/// The current value.
	/// </summary>
	private int _currentValue;

	/// <summary>
	/// The maximum value.
	/// </summary>
	private int _maxValue;
	#endregion Private Attributes

	#region Properties
	/// <summary>
	/// Gets or sets the current value.
	/// </summary>
	/// <value>The current value.</value>
	public int CurrentValue
	{
		get { return _currentValue; }
		set
		{
			_currentValue = Mathf.Clamp(value, 0, _maxValue);
			UpdateValues();
		}
	}

	/// <summary>
	/// Gets or sets the maximum value.
	/// </summary>
	/// <value>The maximum value.</value>
	public int MaximumValue
	{
		get { return _maxValue; }
		set
		{
			_maxValue = Mathf.Max(value, 0);
			UpdateValues();
		}
	}
	#endregion Properties

	#region MonoBehaviour Methods
	/// <summary>
	/// Called on initialization.
	/// </summary>
	void Awake()
	{
		_valueImage = transform.FindChild("Value");
		_labelText = transform.FindChild("Label");
		_iconImage = transform.FindChild("Icon");

		if( _valueImage != null )
		{
			_valueRectTransform = _valueImage.GetComponent<RectTransform>();
			_valueImageRenderer = _valueImage.GetComponent<Image>();

			_valueImageRenderer.color = ValueColor;
		}

		if( _labelText != null )
		{
			_counterLabel = _labelText.GetComponent<Text>();
		}

		if( _iconImage != null )
		{
			_iconImageRenderer = _iconImage.GetComponent<Image>();

			// Create Sprite.
			if( Icon != null )
			{
				var sprite = Sprite.Create(Icon,
				                           new Rect(0, 0, Icon.width, Icon.height),
				                           new Vector2(0.5f, 0.5f), Icon.height );

				_iconImageRenderer.sprite = sprite;
			}
		}

		UpdateValues();
	}
	#endregion MonoBehaviour Methods

	#region Methods
	private void UpdateValues()
	{
		_counterLabel.text = _currentValue + "/" + _maxValue;

		if( _maxValue > 0 )
			_valueRectTransform.anchorMax = new Vector2((float)_currentValue / (float)_maxValue, _valueRectTransform.anchorMax.y);
	}
	#endregion Methods
}
