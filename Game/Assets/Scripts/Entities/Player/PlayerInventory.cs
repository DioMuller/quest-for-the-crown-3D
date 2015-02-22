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
            UseHealthItem();

        if (PlayerMovement.Input.GetButton("UseItem2"))
            UsePotion();
    }

    public int AddHealthItem(int amount)
    {
        return AddItem(ref HealthItems, amount, MaxHealthItems);
    }

    public int AddPotionItem(int amount)
    {
        return AddItem(ref PotionItems, amount, MaxPotionItems);
    }

    public bool UsePotion()
    {
        return UseItem(ref PotionItems, PotionItem.Use);
    }

    public bool UseHealthItem()
    {
        return UseItem(ref HealthItems, HealthItem.Use);
    }

    int AddItem(ref int item, int amount, int max)
    {
        int toAdd = Math.Min(amount, max - item);
        item += toAdd;
        return toAdd;
    }

    bool UseItem(ref int item, Func<GameObject, bool> itemUse)
    {
        if (item > 0 && itemUse(gameObject))
        {
            item--;
            return true;
        }
        return false;
    }
}
