using UnityEngine;
using System.Collections;

public class EnemyCheckpoint : MonoBehaviour
{
	public int Order = 0;

	public Vector3 Position { get; private set; }

	void Start()
	{
		Position = transform.position;
	}
}
