using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    #region Constants
    public readonly static Vector3 InitialCameraDistance = new Vector3(0, 100, -70);
    #endregion Constants

    #region Private Attributes
    /// <summary>
    /// Distance between camera and target.
    /// </summary>
    public Vector3 _distanceDifference = InitialCameraDistance;
    #endregion Private Attributes

    #region Public Attributes
    /// <summary>
    /// Main Game Camera.
    /// </summary>
    public Camera MainCamera;

    /// <summary>
    /// Target object for the camera to follow.
    /// </summary>
    public Vector3 Target;
    #endregion Public Attributes

    #region MonoBehaviour Methods
    /// <summary>
    /// Initializes MonoBehaviour.
    /// </summary>
    void Start()
    {
    }

    /// <summary>
    /// Called once per frame.
    /// </summary>
    void Update()
    {
        transform.position = Target + _distanceDifference;
    }
    #endregion MonoBehaviour Methods

    #region Public Methods
    #endregion Public Methods
}
