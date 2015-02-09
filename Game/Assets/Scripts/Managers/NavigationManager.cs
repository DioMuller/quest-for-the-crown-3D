using System;
using UnityEngine;
using System.Collections;

public class NavigationManager : SingletonBehaviour<NavigationManager> 
{
    public static string NextWaypoint = String.Empty;
    public Transform[] Waypoints;
    public GameObject Player;

    void Start()
    {
        Transform wp = null;

        foreach( Transform way in Waypoints )
        {
            if( way.name == NextWaypoint )
            {                
                wp = way;
            }
        }

        if (wp != null)
        {
            Player.transform.position = wp.position;
        }
    }
}
