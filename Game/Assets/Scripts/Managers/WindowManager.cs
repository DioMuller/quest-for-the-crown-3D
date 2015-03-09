using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;

public class WindowManager : SingletonBehaviour<WindowManager>
{
	public GameObject[] Windows;

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

		EnablePlayerMovement();
	}

	public void OpenWindow(int window)
	{
		if (window < 0 || window >= Windows.Length) return;
		if (Windows[window] == null) return;
		CloseWindow();

		Windows[window].SetActive(true);
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
}
