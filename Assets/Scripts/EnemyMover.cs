using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMover : MonoBehaviour
{
	[SerializeField] List<Waypoint> path = new List<Waypoint>();

	[Tooltip("Measured in Tiles per second.")]
	[SerializeField][Range(0, 5)] float speed = 1;


 
	void OnEnable()
	{
		FindPath();
		ReturnToStart();
		StartCoroutine(FollowPathRoutine());
	}


	void FindPath()
	{
		path.Clear();

		GameObject pathFolder = GameObject.FindGameObjectWithTag("Path");

		foreach (Transform child in pathFolder.transform)
		{
			path.Add(child.GetComponent<Waypoint>());
		}
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

		gameObject.SetActive(false);
	}


	void ReturnToStart() => transform.position = path[0].transform.position;
}
