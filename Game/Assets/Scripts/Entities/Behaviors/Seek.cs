using System.Linq;
using UnityEngine;
using System.Collections;


public class Seek : MovementBehaviour
{
	#region Private Attributes
	/// <summary>
	/// Current Target.
	/// </summary>
	private GameObject _currentTarget;

	/// <summary>
	/// Seconds since last searched for a target.
	/// </summary>
	private float _secondsSinceLastTarget = 0.0f;
	#endregion Private Attributes

	#region Public Attributes
	/// <summary>
	/// Tags the entity will seek.
	/// </summary>
	public string[] TagsToSeek = {"Player"};

	/// <summary>
	/// Seconds to recalculate next target.
	/// </summary>
	public float SecsToRecalculate = 3.0f;
	#endregion Public Attributes

	#region MonoBehaviour Methods
	/// <summary>
	/// Initializes the MonoBehaviour
	/// </summary>
	void Start ()
	{
		StartBehaviour();
		FindNextTarget();
	}
	
	/// <summary>
	/// Called once per frame.
	/// </summary>
	void Update ()
	{
		_secondsSinceLastTarget += Time.deltaTime;

		if (_secondsSinceLastTarget > SecsToRecalculate)
		{
			FindNextTarget();
			_secondsSinceLastTarget = 0.0f;
		}

		if (_currentTarget != null)
		{
			var direction = (_currentTarget.transform.position - transform.position);

			MovementDirection = direction;
		}
	}
	#endregion MonoBehaviour Methods

	#region Internal Methods
	/// <summary>
	/// Finds nearest GameObject and sets as target.
	/// </summary>
	/// <returns></returns>
	public void FindNextTarget()
	{
		if (TagsToSeek.Length < 1) return;

		_currentTarget = null;
		float minDist = float.MaxValue;

		foreach (var tag in TagsToSeek)
		{
			var objects = GameObject.FindGameObjectsWithTag(tag);

			var closest = objects.OrderBy((o) => Vector3.Distance(o.transform.position, this.transform.position)).FirstOrDefault();
			
			if (closest != null)
			{
				var closestDist = Vector3.Distance(closest.transform.position, this.transform.position);

				if (closestDist < minDist)
				{
					_currentTarget = closest;
					minDist = closestDist;
				}
			}
		}

	}
	#endregion Internal Methods
}