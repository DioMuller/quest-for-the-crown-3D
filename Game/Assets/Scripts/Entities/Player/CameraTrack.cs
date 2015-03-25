using UnityEngine;

public class CameraTrack : MonoBehaviour {

    public int CameraNumber;

    // Use this for initialization
    void Start () 
	{
        if (CameraManager.Instance != null)
			CameraManager.Instance.RegisterPlayer(transform);
    }
	
	void OnDestroy()
    {
		if (CameraManager.Instance != null)
			CameraManager.Instance.UnregisterPlayer(transform);
    }
}
