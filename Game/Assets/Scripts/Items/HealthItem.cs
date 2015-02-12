using UnityEngine;

public class HealthItem : ItemBase
{
    public int Ammount = 1;

    protected override void OnPlayerTouch(Collider player)
    {
        var status = player.GetComponent<CharacterStatus>();
        if (status != null)
        {
            status.AddHealth(Ammount);
            Destroy(gameObject);
        }
    }
}
