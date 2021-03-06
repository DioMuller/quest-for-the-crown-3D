using UnityEngine;
using System.Collections;

public class OptionSelection : SingletonBehaviour<OptionSelection>
{
	public GameObject ActionSelectionUI;
	public GameObject MissionSelectionUI;
	public GameObject ShopUI;

	private bool _uiOpen = false;

	public bool IsUIActive { get { return _uiOpen; } }

	void Start()
	{
		CloseAll();
	}

	public void CloseAll()
	{
		if (ActionSelectionUI != null) ActionSelectionUI.SetActive(false);
		if (MissionSelectionUI != null) MissionSelectionUI.SetActive(false);
		if (ShopUI != null ) ShopUI.SetActive(false);

		_uiOpen = false;

		EnablePlayerMovement();
	}

	public void OpenActionSelection()
	{
		if (ActionSelectionUI == null) return;

		if (ActionSelectionUI != null) ActionSelectionUI.SetActive(true);
		if (MissionSelectionUI != null) MissionSelectionUI.SetActive(false);
		if (ShopUI != null) ShopUI.SetActive(false);

		_uiOpen = true;

		DisablePlayerMovement();
	}

	public void OpenMissionSelection()
	{
		if (MissionSelectionUI == null) return;

		if (ActionSelectionUI != null) ActionSelectionUI.SetActive(false);
		if (MissionSelectionUI != null) MissionSelectionUI.SetActive(true);
		if (ShopUI != null) ShopUI.SetActive(false);

		_uiOpen = true;

		DisablePlayerMovement();
	}

	public void OpenShopUI()
	{
		if (ShopUI == null) return;

		if (ActionSelectionUI != null) ActionSelectionUI.SetActive(false);
		if (MissionSelectionUI != null) MissionSelectionUI.SetActive(false);
		if (ShopUI != null) ShopUI.SetActive(true);

		_uiOpen = true;

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
