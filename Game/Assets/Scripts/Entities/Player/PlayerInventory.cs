using UnityEngine;
using System;

public class PlayerInventory : MonoBehaviour
{
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

    public void AddHealthItem(int amount)
    {
        HealthItems += amount;
    }

    public void AddPotionItem(int amount)
    {
        PotionItems += amount;
    }

    public bool UsePotion()
    {
        return UseItem(ref PotionItems, PotionItem.Use);
    }

    public bool UseHealthItem()
    {
        return UseItem(ref HealthItems, HealthItem.Use);
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
