using UnityEngine;
using System.Collections;

public class PlayerRegister : MonoBehaviour 
{
    public int PlayerNumber = 1;

    public Vector3 Checkpoint { get; private set; }

	// Use this for initialization
	void Awake() 
    {
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
    }
}
