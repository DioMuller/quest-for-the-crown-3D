using UnityEngine;
using System.Collections;
using System;

public abstract class ItemBase : MonoBehaviour
{
    public int PickupAmount;

    private Action<PlayerInventory, int> _addToInventory;
    private Func<GameObject, bool> _useItem;

    protected ItemBase(Action<PlayerInventory, int> addToInventory, Func<GameObject, bool> useItem)
    {
        _addToInventory = addToInventory;
        _useItem = useItem;
    }

    /// <summary>
    /// Called when any objects collides with this.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OnPlayerTouch(other);
        }
    }

    void OnPlayerTouch(Collider player)
    {
        var inventory = player.GetComponent<PlayerInventory>();
        if (inventory != null)
        {
            _addToInventory(inventory, PickupAmount);
        }
        else
        {
            while (PickupAmount > 0)
            {
                if (!_useItem(player.gameObject))
                    break;
            }
        }

        if (PickupAmount <= 0)
            Destroy(gameObject);
    }
}
