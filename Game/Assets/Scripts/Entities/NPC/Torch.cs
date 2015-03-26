using UnityEngine;
using System.Collections;

public class Torch : MonoBehaviour 
{
    public GameObject TorchLight;
	public GameObject LightSwitch = null;
    public bool Active = false;

	private MinimapEntity _minimapBlip;

	// Use this for initialization
	void Start ()
	{
		_minimapBlip = GetComponent<MinimapEntity>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (TorchLight.activeSelf && !Active) TorchLight.SetActive(false);
        else if (!TorchLight.activeSelf && Active)
        {
	        TorchLight.SetActive(true);
			if(LightSwitch != null) Destroy(LightSwitch);
			if (_minimapBlip != null) _minimapBlip.SetVisible(false);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Fire")
        {
            Active = true;
        }
    }
}
