using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	#region Private Attributes
	/// <summary>
	/// Distance between camera and target.
	/// </summary>
	public Vector3 _distanceDifference = Vector3.zero;
	#endregion Private Attributes

	#region Public Attributes
	/// <summary>
	/// Main Game Camera.
	/// </summary>
	public Camera MainCamera;

	/// <summary>
	/// Target object for the camera to follow.
	/// </summary>
	public GameObject Target;
	#endregion Public Attributes

	#region MonoBehaviour Methods
	/// <summary>
	/// Initializes MonoBehaviour.
	/// </summary>
	void Start () 
	{
		if (MainCamera != null && Target != null)
		{
			_distanceDifference = transform.position - Target.transform.position;
		}
	}

	/// <summary>
	/// Called once per frame.
	/// </summary>
	void Update () 
	{
		if (MainCamera != null && Target != null)
		{
			transform.position = Target.transform.position + _distanceDifference;
		}
	}
	#endregion MonoBehaviour Methods
}
