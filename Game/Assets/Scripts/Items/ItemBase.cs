using UnityEngine;
using System.Collections;
using System;

public abstract class ItemBase : MonoBehaviour
{
    public bool CanPickup = true;
    public int PickupAmount = 1;

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
        GetComponent<Rigidbody>().velocity = new Vector3(direction.x, 8, direction.y) * 2;
        yield return new WaitForSeconds(0.5f);
        CanPickup = oldPickup;
    }

    /// <summary>
    /// Called when any objects collides with this.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (!CanPickup)
            return;

        if (other.tag == "Player")
        {
            OnPlayerTouch(other);
        }
    }

    void OnPlayerTouch(Collider player)
    {
        PickupAmount -= Pickup(PickupAmount);

        if (PickupAmount <= 0)
            Destroy(gameObject);
    }

	public virtual int Pickup(int amount)
	{
		return amount;
	}

	public static bool Use(CharacterStatus status)
	{
		return true;
	}
}
