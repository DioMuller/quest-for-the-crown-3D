using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterStatus))]
public class PlayerRegister : MonoBehaviour 
{
    private CharacterStatus _status;

    public int PlayerNumber = 1;

    public Vector3 Checkpoint { get; private set; }

	// Use this for initialization
	void Start() 
    {
        _status = GetComponent<CharacterStatus>();

        if( !PlayerManager.Instance.RegisterPlayer(this) )
        {
            Destroy(gameObject);
        }

        Checkpoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnDestroy()
    {
        PlayerManager.Instance.KillPlayer(this);
    }

    void OnTriggerEnter(Collider other)
    {
        if( other.tag == "Checkpoint" )
        {
            Checkpoint = transform.position;
        }

        if (other.tag == "Water")
        {
            transform.position = Checkpoint;
            _status.RemoveHealth(1, null);
        }
    }
}
