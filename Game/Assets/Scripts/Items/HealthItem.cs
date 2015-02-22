﻿using UnityEngine;

public class HealthItem : ItemBase
{
    public HealthItem()
        : base(Pickup, Use)
    {
    }

    public static void Pickup(PlayerInventory inventory, int amount)
    {
        inventory.AddHealthItem(amount);
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
