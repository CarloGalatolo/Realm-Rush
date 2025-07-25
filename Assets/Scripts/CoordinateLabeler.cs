using TMPro;
using UnityEngine;
using UnityEngine.Assertions;


/// <summary>
/// WARNING: This script uses some Editor functionalities. Move it to an Editor folder if you want to build an executable. It's not really necessary in game anyway.
/// </summary>
[ExecuteAlways]
[RequireComponent(typeof(TMP_Text))]
public class CoordinateLabeler : MonoBehaviour
{
	[SerializeField] Color defaultColor = Color.white;
	[SerializeField] Color disabledColor = Color.gray;

	TMP_Text label;
	Waypoint waypoint;

	string tileName;
	Vector2Int coordinates = new Vector2Int();



	void Awake()
	{
		label = GetComponent<TMP_Text>();
		Assert.IsNotNull(label, "CoordinateLabel.Awake(): label not found in prefab.");

		label.enabled = !Application.isPlaying;

		waypoint = GetComponentInParent<Waypoint>();
		Assert.IsNotNull(waypoint, "CoordinateLabel.Awake(): waypoint not found in parent.");

		DisplayCoordinates();    // Call only once at game start but update only in editor.
	}


	void Start()
	{
		tileName = GetComponentInChildren<TileName>().Name;
	}


	void Update()
	{
		if (!Application.isPlaying)   // Execute only in Editor mode.
		{
			DisplayCoordinates();
			UpdateName();
		}

		SetLabelColor();
		ToggleLabels();
	}


	void DisplayCoordinates()
	{
		coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
		coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
		label.text = coordinates.ToString();
	}


	void UpdateName()
	{
		transform.parent.name = coordinates.ToString() + " " + tileName + "Tile";
	}


	void ToggleLabels()
	{
		if (Input.GetKeyDown(KeyCode.C))
		{
			label.enabled = !label.IsActive();
		}
	}


	void SetLabelColor() => label.color = waypoint.IsPlaceable ? defaultColor : disabledColor;
}
