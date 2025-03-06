using TMPro;
using UnityEngine;

[ExecuteAlways]
public class CoordinateLabel : MonoBehaviour
{
	string tileName;
	TMP_Text label;
	Vector2Int coordinates = new Vector2Int();



	void Awake ()
	{
		label = GetComponent<TMP_Text>();
		DisplayCoordinates();	// Call only once at game start but update only in editor.
	}


	void Start ()
	{
		tileName = GetComponentInChildren<TileName>().Name;
	}


	void Update ()
    {
        if (!Application.isPlaying)	// Execute only in Editor mode.
		{
			DisplayCoordinates();
			UpdateName();
		}
    }


	void DisplayCoordinates ()
	{
		coordinates.x = Mathf.RoundToInt( transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x );
		coordinates.y = Mathf.RoundToInt( transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z );
		label.text = coordinates.ToString();
	}


	void UpdateName ()
	{
		transform.parent.name = tileName + "Tile " + coordinates.ToString();
	}
}
