using UnityEngine;

public class MagicPotionItem : ItemBase
{
    public override int Pickup(int amount)
    {
	    return PlayerManager.ObtainItem(Items.MagicPotion, amount);
    }

	public override bool Use(GameObject player)
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
