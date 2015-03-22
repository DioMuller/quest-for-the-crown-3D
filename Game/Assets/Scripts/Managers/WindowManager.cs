using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WindowManager : SingletonBehaviour<WindowManager>
{
	public GameObject[] Windows;
	public EventSystem EventSystem;

	private bool _activeWindow = false;

	void Start()
	{
		CloseWindow();
	}

	public void CloseWindow()
	{
		foreach (var window in Windows)
		{
			window.SetActive(false);
		}

		_activeWindow = false;

		EnablePlayerMovement();
	}

	public void OpenWindow(int window)
	{
		if (window < 0 || window >= Windows.Length) return;
		if (Windows[window] == null) return;
		CloseWindow();

		Windows[window].SetActive(true);
		try
		{
			Windows[window].GetComponentInChildren<Button>().Select();
		}
		catch (Exception)
		{
			Debug.LogWarning("Active UI does not have a button to focus.");
			throw;
		}

		_activeWindow = true;
		DisablePlayerMovement();
	}

	public void EnablePlayerMovement()
	{
		Time.timeScale = 1.0f;
	}

	public void DisablePlayerMovement()
	{
		Time.timeScale = 0.0f;
	}

	void Update()
	{
		if (_activeWindow)
		{
			if (Input.GetButton("Submit"))
			{
				Windows.First((w) => w.activeSelf).GetComponentInChildren<Button>().onClick.Invoke();
			}
		}
	}
}
