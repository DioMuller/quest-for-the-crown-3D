using UnityEngine;
using System.Collections;
using System;

public abstract class ItemBase : MonoBehaviour
{
    public bool CanPickup = true;
    public int PickupAmount = 1;

    private Func<PlayerInventory, int, int> _addToInventory;
    private Func<GameObject, bool> _useItem;

    protected ItemBase(Func<PlayerInventory, int, int> addToInventory, Func<GameObject, bool> useItem)
    {
        _addToInventory = addToInventory;
        _useItem = useItem;
    }

    public void Start()
    {
        StartCoroutine(StartDrop());
    }

    IEnumerator StartDrop()
    {
        var direction = new Vector2(UnityEngine.Random.value - 0.5f, UnityEngine.Random.value - 0.5f);
        direction.Normalize();
        transform.position += new Vector3(direction.x, 0, direction.y);
        var oldPickup = CanPickup;
        rigidbody.velocity = new Vector3(direction.x, 8, direction.y) * 2;
        yield return new WaitForSeconds(0.5f);
        CanPickup = oldPickup;
    }

    /// <summary>
    /// Called when any objects collides with this.
    /// </summary>
    /// <param name="other"></param>
    void OnCollisionEnter(Collision collision)
    {
        if (!CanPickup)
            return;

        var other = collision.collider;
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
            PickupAmount -= _addToInventory(inventory, PickupAmount);
        }
        else
        {
            while (PickupAmount > 0)
            {
                if (!_useItem(player.gameObject))
                    break;
                PickupAmount--;
            }
        }

        if (PickupAmount <= 0)
            Destroy(gameObject);
    }
}
