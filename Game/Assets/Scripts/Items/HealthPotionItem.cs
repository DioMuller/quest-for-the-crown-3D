using UnityEngine;

public class HealthPotionItem : ItemBase
{
    public override int Pickup(int amount)
    {
        return PlayerManager.ObtainItem( Items.HealthPotion, amount);
    }

	public override bool Use(GameObject player)
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
