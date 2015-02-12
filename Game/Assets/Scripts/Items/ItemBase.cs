using UnityEngine;
using System.Collections;

public abstract class ItemBase : MonoBehaviour
{

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

    protected abstract void OnPlayerTouch(Collider player);
}
