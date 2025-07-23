using UnityEngine;
using UnityEngine.Assertions;


public class Waypoint : MonoBehaviour
{
	[SerializeField] Tower tower;
	
	[SerializeField] bool isPlaceable;
	public bool IsPlaceable => isPlaceable;



	void Awake()
	{
		Assert.IsNotNull(tower, "Waypoint.Awake(): tower not found in prefab.");
	}


	void OnMouseDown()
	{
		if (!isPlaceable)
		{
			return;
		}

		bool isPlaced = tower.CreateTower(transform.position);
		isPlaceable = !isPlaced;
	}
}
