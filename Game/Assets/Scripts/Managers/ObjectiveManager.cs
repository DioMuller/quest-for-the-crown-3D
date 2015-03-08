using System;
using System.Linq;
using UnityEngine;
using System.Collections;

[System.Serializable]
public class Objective
{
	public string Name;
	public int CurrentQuantity = 0;
	public int QuantityNeeded;

	public bool Complete
	{
		get { return CurrentQuantity >= QuantityNeeded; }
	}
}

public class ObjectiveManager : SingletonBehaviour<ObjectiveManager>
{
	public Objective[] Objectives;

	public void AddToObjective(string objectiveName)
	{
		var objective = Objectives.FirstOrDefault(o => o.Name == objectiveName);

		if (objective != null)
		{
			objective.CurrentQuantity++;

			if( Objectives.Count(o => !o.Complete) == 0) CompleteMission();
		}
	}

	public void CompleteMission()
	{
		print("Mission Complete!");
	}
}
