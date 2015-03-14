using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemGUI : SingletonBehaviour<ItemGUI>
{
	public Text HealthPotionLabel;
	public Text MagicPotionLabel;
	public Text BombLabel;
	public Text MedalLabel;

	public void UpdateItems()
	{
		HealthPotionLabel.text = PlayerManager.HealthPotions.ToString();
		MagicPotionLabel.text = PlayerManager.MagicPotions.ToString();
		BombLabel.text = PlayerManager.Bombs.ToString();
		MedalLabel.text = PlayerManager.Medals.ToString();
	}
}
