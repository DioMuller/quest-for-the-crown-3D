using UnityEngine;

public class CameraTrack : MonoBehaviour {
    private CameraManager _cameraManager;

    public GameObject CameraManager;
    public int CameraNumber;

    // Use this for initialization
    void Start () {
        if (CameraManager != null)
        {
            _cameraManager = CameraManager.GetComponent<CameraManager>();
            if (_cameraManager != null)
                _cameraManager.RegisterPlayer(transform);
        }
    }
	
	void OnDestroy()
    {
        if (_cameraManager != null)
            _cameraManager.UnregisterPlayer(transform);
    }
}
