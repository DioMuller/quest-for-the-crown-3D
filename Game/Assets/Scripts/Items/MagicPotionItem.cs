using UnityEngine;

public class MagicPotionItem : ItemBase
{
    public override int Pickup(int amount)
    {
	    return PlayerManager.ObtainItem(Items.MagicPotion, amount);
    }

	public static new bool Use(CharacterStatus status)
    {
        const int RestoreAmount = 10;

        if (status != null)
        {
			if (status.RestoreMagic(RestoreAmount) > 0 )
			{
				PlayerManager.UseItem(Items.MagicPotion);
				return true;
			}
        }
        return false;
    }
}
