using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteAlways]
public class CoordinateLabel : MonoBehaviour
{
	TMP_Text label;
	Vector2Int coordinates = new Vector2Int();



	void Awake ()
	{
		label = GetComponent<TMP_Text>();
		DisplayCoordinates();	// Call only once at game start but update only in editor.
	}


    void Update ()
    {
        if (!Application.isPlaying)	// Execute only in Editor mode.
		{
			DisplayCoordinates();
		}
    }


	void DisplayCoordinates ()
	{
		coordinates.x = Mathf.RoundToInt( transform.parent.position.x / 10 );
		coordinates.y = Mathf.RoundToInt( transform.parent.position.z / 10 );
		label.text = "(" + coordinates.x + "," + coordinates.y + ")";
	}
}
