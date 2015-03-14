using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public enum Weapons
{
    Bow,
    Fireball,
    Boomerang
}

public enum Items
{
    HealthPotion,
    MagicPotion,
    Bomb,
    Medal
}

public class PlayerManager : SingletonBehaviour<PlayerManager>
{
    private static int playerCount = 1;

    #region Weapons and Items
    // Hard-Coded for time constrains.
    public static bool HasBow { get; private set; }
	public static bool HasFireball { get; private set; }
	public static bool HasBoomerang { get; private set; }

	public static int HealthPotions { get; private set; }
	public static int MagicPotions { get; private set; }
	public static int Bombs { get; private set; }
	public static int Medals { get; private set; }
    #endregion Weapons and Items

    private List<PlayerRegister> _players = new List<PlayerRegister>();

    public bool RegisterPlayer( PlayerRegister playerData )
    {
        if (playerData.PlayerNumber > playerCount || playerData.PlayerNumber <= 0) return false;
        if( _players.Contains(playerData) ) return true;
        if( _players.Count( p => p.PlayerNumber == playerData.PlayerNumber ) > 0 ) return false;

        _players.Add(playerData);
        return true;
    }

    public bool KillPlayer( PlayerRegister playerData )
    {
        return _players.Remove(playerData);
    }

    public void AddPlayer()
    {
        if (playerCount >= 2) return;
        else playerCount++;
    }

    public static void ResetGame()
    {
        playerCount = 1;

        HasBow = false;
        HasFireball = false;
        HasBoomerang = false;

        HealthPotions = 0;
        MagicPotions = 0;
        Bombs = 0;
        Medals = 0;
    }

	//public static bool UseItem(Items item)
	//{
	//	switch(item)
	//	{
	//		case Items.HealthPotion:
	//			if (HealthPotions <= 0) return false;
	//			HealthPotions--;
	//			return true;
	//		case Items.MagicPotion:
	//			if (MagicPotions <= 0) return false;
	//			MagicPotions--;
	//			return true;
	//		case Items.Bomb:
	//			if (Bombs <= 0) return false;
	//			Bombs--;
	//			return true;
	//		case Items.Medal:
	//			if (Medals <= 0) return false;
	//			Medals--;
	//			return true;
	//		default:
	//			return false;
	//	}
	//}

	public static int ObtainItem(Items item, int quantity)
	{
		switch (item)
		{
			case Items.HealthPotion:
				HealthPotions = (HealthPotions + quantity);
				ItemGUI.Instance.UpdateItems();
				break;
			case Items.MagicPotion:
				MagicPotions = (MagicPotions + quantity);
				ItemGUI.Instance.UpdateItems();
				break;
			case Items.Bomb:
				Bombs = (Bombs + quantity);
				ItemGUI.Instance.UpdateItems();
				break;
			case Items.Medal:
				Medals = (Medals + quantity);
				ItemGUI.Instance.UpdateItems();
				break;
			default:
				break;
		}

		return quantity;
	}

	public static int GetQuantity(Items item)
	{
		switch (item)
		{
			case Items.HealthPotion:
				return HealthPotions;
			case Items.MagicPotion:
				return MagicPotions;
			case Items.Bomb:
				return Bombs;
			case Items.Medal:
				return Medals;
			default:
				return 0;
		}
	}

	public static void ObtainWeapon(Weapons weapon)
    {
        switch(weapon)
        {
            case Weapons.Bow:
                HasBow = true;
                break;
            case Weapons.Fireball:
                HasFireball = true;
                break;
            case Weapons.Boomerang:
                HasBoomerang = true;
                break;
        }
    }
}
