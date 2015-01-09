using UnityEngine;
using System.Collections;

public class PerformanceManager : MonoBehaviour 
{
	#region Singleton
	/// <summary>
	/// Gets the instance.
	/// </summary>
	/// <value>The singleton instance.</value>
	public static PerformanceManager Instance { get; private set; }
	#endregion Singleton
	
	#region Public Attributes
	/// <summary>
	/// Current FPS.
	/// </summary>
	public int FPS = 0;
	#endregion Public Attributes
	
	#region MonoBehaviour Methods
	/// <summary>
	/// Initializes MonoBehaviour.
	/// </summary>
	void Awake() 
	{
		Instance = this;
	}

	/// <summary>
	/// Called once per frame.
	/// </summary>
	void Update()
	{
		FPS = Mathf.RoundToInt(1.0f/Time.deltaTime);
	}
	#endregion MonoBehaviour Methods
}
