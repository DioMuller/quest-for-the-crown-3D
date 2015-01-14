using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class CircleBar : MonoBehaviour
{
	private Image _image;
	public Gradient Colors;

	public float CurrentValue = 1;
	public float MaximumValue = 1;

    void Start()
    {
	    _image = GetComponent<Image>();
		_image.type = Image.Type.Filled;
    }

    void Update()
    {
	    float percent = CurrentValue/MaximumValue;

		_image.fillAmount = Mathf.Max(percent, 0.001f);

		_image.color = Colors.Evaluate(1.0f - percent);
    }

     
}
