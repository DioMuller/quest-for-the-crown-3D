using UnityEngine;
using System.Collections;

public class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T>
{
    public static T Instance { get; protected set; }

	// Use this for initialization
	void Awake () 
    {
        Instance = this as T; 
	}
}
