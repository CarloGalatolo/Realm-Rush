using System;
using UnityEngine;

[Serializable]
public class Node
{
	public Vector2Int coordinates = new Vector2Int();
	public bool isWalkable;
	public bool isExplored;
	public bool isPath;
	public Node connectedTo;



	// CONSTRUCTOR
	public Node(Vector2Int coordinates, bool isWalkable)
	{
		this.isWalkable = isWalkable;
		this.coordinates = coordinates;
	}
}
