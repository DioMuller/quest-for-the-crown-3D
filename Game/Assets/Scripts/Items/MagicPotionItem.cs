using UnityEngine;

public class MagicPotionItem : ItemBase
{
	public MagicPotionItem()
        : base(Pickup, Use)
    {
    }

    public static int Pickup(PlayerInventory inventory, int amount)
    {
        return inventory.AddMagicPotions(amount);
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
