using UnityEngine;
using System.Collections;

public class MissionObjective : MonoBehaviour
{
	public string Objective = "";

	void OnDestroy()
	{
		if (ObjectiveManager.Instance != null)
		{
			ObjectiveManager.Instance.AddToObjective(Objective);
		}
	}
}
