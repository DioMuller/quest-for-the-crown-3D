using UnityEngine;
using System.Linq;
using System.Collections;

public class TargetSelector : MonoBehaviour 
{
	#region Public Attributes
	/// <summary>
	/// Tags the entity will seek.
	/// </summary>
	public string[] TagsToTarget = { "Player" };

	/// <summary>
	/// Seconds to recalculate next target.
	/// </summary>
	public float SecsToRecalculate = 3.0f;

	/// <summary>
	/// Minimum distance from target.
	/// </summary>
	public float MinDistanceFromTarget = 100.0f;
	#endregion Public Attributes

    #region Private Attributes
    private bool _isTargetFixed = false;
    #endregion Private Attributes

    #region Properties
    /// <summary>
	/// Current Target.
	/// </summary>
	public GameObject CurrentTarget { get; private set; }
	#endregion Properties

	// Use this for initialization
	void OnEnable () 
	{
		InvokeRepeating("FindNextTarget", 0.0f, SecsToRecalculate);
	}
	
	// Update is called once per frame
	void OnDisable () 
	{
		CancelInvoke("FindNextTarget");
	}

	#region Methods
    public void SetTarget(GameObject target)
    {
        _isTargetFixed = true;
        CurrentTarget = target;
    }

	/// <summary>
	/// Finds nearest GameObject and sets as target.
	/// </summary>
	/// <returns></returns>
	public void FindNextTarget()
	{
		if (TagsToTarget.Length < 1) return;

        if (_isTargetFixed && CurrentTarget != null && CurrentTarget.activeInHierarchy) return;

        _isTargetFixed = false;
		CurrentTarget = null;
		float minDist = MinDistanceFromTarget;

		foreach (var tag in TagsToTarget)
		{
			var objects = GameObject.FindGameObjectsWithTag(tag);

			var closest = objects.OrderBy((o) => Vector3.Distance(o.transform.position, this.transform.position)).FirstOrDefault();

			if (closest != null)
			{
				var closestDist = Vector3.Distance(closest.transform.position, this.transform.position);

				if (closestDist < minDist)
				{
					CurrentTarget = closest;
					minDist = closestDist;
				}
			}
		}

	}
	#endregion Methods
}
