using UnityEngine;

public class HealthPotionItem : ItemBase
{
    public override int Pickup(int amount)
    {
        return PlayerManager.ObtainItem( Items.HealthPotion, amount);
    }

	public static new bool Use(CharacterStatus status)
    {
        const int RestoreAmount = 3;

        if (status != null)
        {
			if( PlayerManager.HealthPotions > 0 )
			{
				if (status.AddHealth(RestoreAmount) > 0)
				{
					PlayerManager.UseItem(Items.HealthPotion);
					return true;
				}
			}
        }
        return false;
    }
}
