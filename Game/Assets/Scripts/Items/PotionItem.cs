using UnityEngine;

public class PotionItem : ItemBase
{
    public PotionItem()
        : base(Pickup, Use)
    {
    }

    public static void Pickup(PlayerInventory inventory, int amount)
    {
        inventory.AddPotionItem(amount);
    }

    public static bool Use(GameObject player)
    {
        const int RestoreAmount = 1;

        var status = player.GetComponent<CharacterStatus>();
        if (status != null)
        {
            return status.RestoreMagic(RestoreAmount) > 0;
        }
        return false;
    }
}
