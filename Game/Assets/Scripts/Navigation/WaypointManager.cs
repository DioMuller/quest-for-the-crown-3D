using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Linq;

public class WaypointManager : SingletonBehaviour<WaypointManager>
{
	private List<EnemyCheckpoint> _waypoints = new List<EnemyCheckpoint>();

	public static void RegisterWaypoint(EnemyCheckpoint checkpoint)
	{
		Instance._waypoints.Add(checkpoint);
	}

	public static EnemyCheckpoint GetCheckpoint(int num)
	{
		// Returns an random instance from that order.
		return Instance._waypoints.OrderBy((c) => Random.Range(0, 1000))
					   .FirstOrDefault((c) => c.Order == num);
	}
}
