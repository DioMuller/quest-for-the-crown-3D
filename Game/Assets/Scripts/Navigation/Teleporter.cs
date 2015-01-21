using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour 
{
    public string Map;
    public string Waypoint;

	void OnTriggerEnter(Collider other)
    {
        if( other.tag == "Player" )
        {
            Application.LoadLevel(Map);
        }
    }
}
