using UnityEngine;
using System.Collections;

public class Torch : MonoBehaviour 
{
    public GameObject TorchLight;
    public bool Active = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (TorchLight.activeSelf && !Active) TorchLight.SetActive(false);
        else if (!TorchLight.activeSelf && Active) TorchLight.SetActive(true);
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Fire")
        {
            Active = true;
        }
    }
}
