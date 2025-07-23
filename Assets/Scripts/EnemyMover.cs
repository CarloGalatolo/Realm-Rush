using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;


[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
	[SerializeField] List<Waypoint> path = new List<Waypoint>();

	[Tooltip("Measured in Tiles per second.")]
	[SerializeField][Range(0, 5)] float speed = 1;


	Enemy enemy;



	void OnEnable()
	{
		FindPath();
		ReturnToStart();
		StartCoroutine(FollowPathRoutine());
	}


	void Awake()
	{
		enemy = GetComponent<Enemy>();	// Required.
	}


	void FindPath()
	{
		path.Clear();

		GameObject pathFolder = GameObject.FindGameObjectWithTag("Path");

		foreach (Transform child in pathFolder.transform)
		{
			Waypoint waypoint = child.GetComponent<Waypoint>();

			if (waypoint != null)
			{
				path.Add(waypoint);
			}
			else
			{
				Debug.LogWarning("Found a tile that's not a Wayponint inside the Path!");
			}
		}
	}


	void GoalReached()
	{
		enemy.StealGold();
		gameObject.SetActive(false);
	}


	IEnumerator FollowPathRoutine()
	{
		foreach (Waypoint waypoint in path)
		{
			Vector3 startPosition = this.transform.position;
			Vector3 endPosition = waypoint.transform.position;
			float travelPercent = 0;

			transform.LookAt(endPosition);

			while (travelPercent <= 1)
			{
				travelPercent += speed * Time.deltaTime;
				this.transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
				yield return null;
			}
		}

		GoalReached();
	}
	

	void ReturnToStart() => transform.position = path[0].transform.position;
}
