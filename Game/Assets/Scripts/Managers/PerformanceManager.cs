using UnityEngine;
using System.Collections;

public class PerformanceManager : SingletonBehaviour<PerformanceManager> 
{
	#region Public Attributes
	/// <summary>
	/// Current FPS.
	/// </summary>
	public int FPS = 0;
	#endregion Public Attributes
	
	#region MonoBehaviour Methods
	/// <summary>
	/// Called once per frame.
	/// </summary>
	void Update()
	{
		FPS = Mathf.RoundToInt(1.0f/Time.deltaTime);
	}
	#endregion MonoBehaviour Methods
}
