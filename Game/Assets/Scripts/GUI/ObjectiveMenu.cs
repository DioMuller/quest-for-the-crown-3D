using UnityEngine;
using System.Collections;

public class ObjectiveMenu : SingletonBehaviour<ObjectiveMenu>
{
	private Canvas _canvas;
	private bool _pressed = false;
	private bool _visible = false;

	void Awake()
	{
		_canvas = GetComponent<Canvas>();
		Hide();
	}

	void Update()
	{
		if (Input.GetButton("Objectives"))
		{
			if (!_pressed)
			{
				if( _visible ) Hide();
				else Show();

				_pressed = true;
			}
		}
		else
		{
			_pressed = false;
		}
		
	}

	public void Show()
	{
		var objectives = GetComponentsInChildren<ObjectiveLabel>();

		foreach (var objective in objectives)
		{
			objective.UpdateData();
		}

		_canvas.enabled = true;
		_visible = true;
		Time.timeScale = 0.0f;
	}

	public void Hide()
	{
		_canvas.enabled = false;
		_visible = false;
		Time.timeScale = 1.0f;
	}
}
