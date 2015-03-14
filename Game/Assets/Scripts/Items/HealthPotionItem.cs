using UnityEngine;

public class HealthPotionItem : ItemBase
{
	public HealthPotionItem()
        : base(Pickup, Use)
    {
    }

    public static int Pickup(PlayerInventory inventory, int amount)
    {
        return inventory.AddHealthPotions(amount);
    }

    public static bool Use(GameObject player)
    {
        const int RestoreAmount = 1;

        var status = player.GetComponent<CharacterStatus>();
        if (status != null)
        {
            return status.AddHealth(RestoreAmount) > 0;
        }
        return false;
    }
}
