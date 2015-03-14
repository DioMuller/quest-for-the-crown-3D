using UnityEngine;
using System;

public class PlayerInventory : MonoBehaviour
{
    const int MaxHealthItems = 10;
    const int MaxPotionItems = 10;

    PlayerMovement PlayerMovement;
    CharacterStatus CharacterStatus;

    public int PotionItems;
    public int HealthItems;

    // Use this for initialization
    void Start()
    {
        PlayerMovement = gameObject.GetComponent<PlayerMovement>();
        CharacterStatus = gameObject.GetComponent<CharacterStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.Input.GetButton("UseItem1"))
            UseHealthPotion();

        if (PlayerMovement.Input.GetButton("UseItem2"))
            UseMagicPotion();
    }

    public int AddHealthPotions(int amount)
    {
	    return PlayerManager.ObtainItem(Items.HealthPotion, amount);
    }

    public int AddMagicPotions(int amount)
    {
		return PlayerManager.ObtainItem(Items.MagicPotion, amount);
    }

	public int AddBombs(int amount)
	{
		return PlayerManager.ObtainItem(Items.Bomb, amount);
	}

	public int AddMedals(int amount)
	{
		return PlayerManager.ObtainItem(Items.Medal, amount);
	}

    public bool UseHealthPotion()
    {
		return UseItem(Items.HealthPotion, HealthPotionItem.Use);
    }

    public bool UseMagicPotion()
    {
		return UseItem(Items.MagicPotion, HealthPotionItem.Use);
    }

    int AddItem(ref int item, int amount, int max)
    {
        int toAdd = Math.Min(amount, max - item);
        item += toAdd;
        return toAdd;
    }

    bool UseItem(Items item, Func<GameObject, bool> itemUse)
    {
        if (PlayerManager.GetQuantity(item) > 0 && itemUse(gameObject) )
        {
	        if (itemUse(gameObject))
	        {
		        ItemGUI.Instance.UpdateItems();
		        return true;
	        }
        }

        return false;
    }
}
