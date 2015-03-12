using UnityEngine;
using System.Collections;

public class PlayerRegister : MonoBehaviour 
{
    public int PlayerNumber = 1;

	// Use this for initialization
	void Awake() 
    {
        if( !PlayerManager.Instance.RegisterPlayer(this) )
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
