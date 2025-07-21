using UnityEngine;


[ExecuteAlways]
public class TileRotation : MonoBehaviour
{
	[SerializeField][Range(0, 3)] int rotation90DegSnaps = 0;
	[SerializeField] Transform model;



	void OnValidate()
	{
		SnapRotate();
	}


	void Awake()
	{
		SnapRotate();
	}


	void SnapRotate()
	{
		if (model)
		{
			model.transform.rotation = Quaternion.Euler(new Vector3(0, 90 * rotation90DegSnaps, 0));
		}
	}
}
