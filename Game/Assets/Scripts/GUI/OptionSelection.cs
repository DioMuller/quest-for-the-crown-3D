using UnityEngine;
using System.Collections;

public class OptionSelection : SingletonBehaviour<OptionSelection>
{
	public GameObject ActionSelectionUI;
	public GameObject MissionSelectionUI;
	public GameObject ShopUI;

	void Start()
	{
		CloseAll();
	}

	public void CloseAll()
	{
		print("Deactivating all UIs.");
		if (ActionSelectionUI != null) ActionSelectionUI.SetActive(false);
		if (MissionSelectionUI != null) MissionSelectionUI.SetActive(false);
		if (ShopUI != null ) ShopUI.SetActive(false);

		EnablePlayerMovement();
	}

	public void OpenActionSelection()
	{
		if (ActionSelectionUI == null) return;

		if (ActionSelectionUI != null) ActionSelectionUI.SetActive(true);
		if (MissionSelectionUI != null) MissionSelectionUI.SetActive(false);
		if (ShopUI != null) ShopUI.SetActive(false);

		DisablePlayerMovement();
	}

	public void OpenMissionSelection()
	{
		if (MissionSelectionUI == null) return;

		if (ActionSelectionUI != null) ActionSelectionUI.SetActive(false);
		if (MissionSelectionUI != null) MissionSelectionUI.SetActive(true);
		if (ShopUI != null) ShopUI.SetActive(false);

		DisablePlayerMovement();
	}

	public void OpenShopUI()
	{
		if (ShopUI == null) return;

		if (ActionSelectionUI != null) ActionSelectionUI.SetActive(false);
		if (MissionSelectionUI != null) MissionSelectionUI.SetActive(false);
		if (ShopUI != null) ShopUI.SetActive(true);

		DisablePlayerMovement();
	}

	public void EnablePlayerMovement()
	{
		
	}

	public void DisablePlayerMovement()
	{
		
	}
}
