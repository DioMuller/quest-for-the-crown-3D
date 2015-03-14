using UnityEngine;

[RequireComponent(typeof(CharacterStatus))]
public class DropItem : MonoBehaviour 
{

    public Transform Item;
    public float Chance;

	private CharacterStatus _status;
	private bool _spawned = false;

	void Start()
	{
		_status = GetComponent<CharacterStatus>();
	}

    void Update()
    {
		if (!_spawned && _status.IsDead)
		{
			_spawned = true;

		    if (Random.value <= Chance)
		    {
			    Instantiate(Item, transform.position, Quaternion.identity);
		    }
	    }
    }
}
