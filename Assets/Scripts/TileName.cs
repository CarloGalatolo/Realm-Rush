using UnityEngine;

[ExecuteAlways]
public class TileName : MonoBehaviour
{
	public string Name { get; private set; }

	void Awake ()
	{
		Name = GetComponentInChildren<MeshRenderer>()?.name + " ";
	}
}
