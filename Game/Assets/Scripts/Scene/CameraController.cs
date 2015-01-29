using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    #region Private Attributes
    private Rect _bounds;
    #endregion Private Attributes

    #region Public Attributes
    /// <summary>
    /// Distance between camera and target.
    /// </summary>
    public Vector3 DistanceDifference = new Vector3(0, 10, -10);

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
        _bounds = new Rect(
            transform.position.x + CameraManager.Instance.Bounds.x,
            transform.position.z + CameraManager.Instance.Bounds.y,
            transform.position.x + CameraManager.Instance.Bounds.width,
            transform.position.z + CameraManager.Instance.Bounds.height
        );
    }

    /// <summary>
    /// Called once per frame.
    /// </summary>
    void LateUpdate()
    {
        var newPos = Target + DistanceDifference;

        transform.position = new Vector3(Mathf.Clamp(newPos.x, _bounds.x, _bounds.width),
                                        transform.position.y,
                                        Mathf.Clamp(newPos.z, _bounds.y, _bounds.height));
    }
    #endregion MonoBehaviour Methods

    #region Public Methods
    #endregion Public Methods
}
