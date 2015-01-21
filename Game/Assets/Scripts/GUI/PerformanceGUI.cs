using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Canvas))]
public class PerformanceGUI : MonoBehaviour
{
    #region Public Attributes
    /// <summary>
    /// Is the GUI visible?
    /// </summary>
    public bool IsVisible = true;

    /// <summary>
    /// The scene performance manager.
    /// </summary>
    public PerformanceManager Manager;
    #endregion Public Attributes

    #region Private Attributes
    /// <summary>
    /// Performance GUI canvas.
    /// </summary>
    private Canvas _canvas;

    /// <summary>
    /// FPS Counter label component.
    /// </summary>
    private Text _fpsCounter;
    #endregion Private Attributes

    #region MonoBehaviour Methods
    /// <summary>
    /// Use for initialization.
    /// </summary>
	void Start () 
    {
        _canvas = GetComponent<Canvas>();
        _fpsCounter = transform.FindChild("FPSCounter").GetComponent<Text>();

        InvokeRepeating("UpdatePerformance", 0.0f, 1.0f);
	}
	
    /// <summary>
    /// Called once per frame.
    /// </summary>
	void UpdatePerformance () 
    {
        if(!IsVisible)
        {
            if (_canvas.enabled) _canvas.enabled = false;
            return;
        }

        if (!_canvas.enabled) _canvas.enabled = true;
        _fpsCounter.text = Manager.FPS.ToString();
    }
    #endregion MonoBehaviour Methods
}
