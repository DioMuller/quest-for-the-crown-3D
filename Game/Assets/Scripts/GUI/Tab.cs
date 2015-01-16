using UnityEngine;
using System.Collections;

public class Tab : MonoBehaviour 
{
	/// <summary>
	/// The identifier.
	/// </summary>
	public int Id;

	/// <summary>
	/// Use this for initialization.
	/// </summary>
	void Start () 
	{
		if( TabManager.Instance != null )
		{
			TabManager.Instance.AddTab(Id, gameObject);
		}
	}
}
