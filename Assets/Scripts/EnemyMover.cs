using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
	[SerializeField] List<Waypoint> path = new List<Waypoint>();
	[SerializeField] float waitTimeSeconds = 1;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine( FollowPathRoutine() );
    }


	IEnumerator FollowPathRoutine ()
	{
		foreach (Waypoint waypoint in path)
		{
			this.transform.position = waypoint.transform.position;
			yield return new WaitForSeconds(waitTimeSeconds);
		}
	}
}
