using UnityEngine;


public class Waypoint : MonoBehaviour
{
	[SerializeField] GameObject towerPrefab;
	
	[SerializeField] bool isPlaceable;
	public bool IsPlaceable => isPlaceable;



	void OnMouseDown()
	{
		if (isPlaceable && towerPrefab)
		{
			Instantiate(towerPrefab, this.transform);
			isPlaceable = false;
		}
	}
}
