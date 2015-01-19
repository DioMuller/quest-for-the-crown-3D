using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class CameraManager : MonoBehaviour
{
    #region Constants
    // TODO: Split based on camera view
    public const float SplitDistance = 100;
    #endregion

    #region Static
    public static CameraManager Instance { get; private set; }
    #endregion

    #region Private Attributes
    bool? _split = null;
    Camera _camera1;
    Camera _camera2;
    Camera _minimap2;
    CameraController _camera1Controller;
    CameraController _camera2Controller;

    Transform _player1;
    Transform _player2;
    #endregion

    #region Public Attributes
    public Transform CameraController1;
    public Transform CameraController2;
    #endregion

    #region MonoBehaviour Methods
    /// <summary>
    /// Initializes MonoBehaviour.
    /// </summary>
    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {
        _camera1Controller = CameraController1.GetComponent<CameraController>();
        _camera2Controller = CameraController2.GetComponent<CameraController>();

        _camera1 = CameraController1.FindChild("Camera").GetComponent<Camera>();
        _camera2 = CameraController2.FindChild("Camera").GetComponent<Camera>();

        _minimap2 = CameraController2.FindChild("Minimap").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_player1 == null && _player2 == null)
            return;

        Transform p1T = _player1 != null ? _player1.transform : null;
        Transform p2T = _player2 != null ? _player2.transform : null;
        Transform pXT = p1T ?? p2T;

        var center = p1T != null && p2T != null ? (p1T.position + p2T.position) / 2 :
                     pXT != null ? pXT.position : Vector3.zero;

        if (_player1 != null && _player2 != null)
        {
            var dist = _player1.position - _player2.position;
            var distLen = new Vector2(dist.x, dist.z).magnitude;

            if (distLen >= SplitDistance)
            {
                SplitScreen(_player1.position, _player2.position);
                return;
            }
        }
        SingleCamera(center);
    }
    #endregion

    #region Private Methods
    void SingleCamera(Vector3 targetPosition)
    {
        _camera1Controller.Target = targetPosition;

        if (_split != false)
        {
            _camera2.enabled = false;
            _minimap2.enabled = false;

            _camera1.rect = new Rect(0, 0, 1, 1);
            _camera2Controller.enabled = false;
            _split = false;
        }
    }

    void SplitScreen(Vector3 target1, Vector3 target2)
    {
        _camera1Controller.Target = target1;
        _camera2Controller.Target = target2;

        if (_split != true)
        {
            _camera2.enabled = true;
            _minimap2.enabled = true;

            _camera1.rect = new Rect(0, 0.5f, 1, 0.5f);
            _camera2.rect = new Rect(0, 0, 1, 0.5f);
            _camera2Controller.enabled = true;
            _split = true;
        }
    }
    #endregion Private Methods

    #region Public Methods
    public void RegisterPlayer(Transform player)
    {
        switch (player.GetComponent<CameraTrack>().CameraNumber)
        {
            case 1:
                _player1 = player;
                break;
            case 2:
                _player2 = player;
                break;
            default:
                throw new ArgumentOutOfRangeException("player.GetComponent<CameraTrack>().CameraNumber");
        }
    }

    public void UnregisterPlayer(Transform player)
    {
        if (_player1 == player)
            _player1 = null;

        else if (_player2 == player)
            _player2 = null;
    }
    #endregion
}
