using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrailEffect : MonoBehaviour 
{
    public GameObject Trail;

    private Stack<GameObject> _activeTrails = new Stack<GameObject>();

    void OnEnable()
    {
        var trail = Instantiate(Trail);
        trail.transform.parent = transform;
        trail.transform.localPosition = Vector3.zero;
        trail.transform.localEulerAngles = Vector3.zero;

        _activeTrails.Push(trail);
    }

    void OnDisable()
    {
        while(_activeTrails.Count > 0)
        {
            Destroy(_activeTrails.Pop());
        }
    }
}
