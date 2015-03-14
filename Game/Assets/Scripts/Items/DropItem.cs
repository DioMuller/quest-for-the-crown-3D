using UnityEngine;

public class DropItem : MonoBehaviour {

    public Transform Item;
    public float Chance;

    void OnDestroy()
    {
        if (Random.value <= Chance)
        {
            Instantiate(Item, transform.position, Quaternion.identity);
        }
    }
}
