using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;


public class Pathfinder : MonoBehaviour
{
	[SerializeField] Vector2Int startCoordinates;
	[SerializeField] Vector2Int destinationCoordinates;

	GridManager gridManager;
	Node startNode;
	Node destinationNode;
	Node currentSearchNode;

	Queue<Node> frontier = new Queue<Node>();
	Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();

	readonly Vector2Int[] DIRECTIONS = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };



	void Awake()
	{
		gridManager = FindObjectOfType<GridManager>();
		Assert.IsNotNull(gridManager, "Pathfinder.Awake(): gridManager not found in the scene.");

	}


	void Start()
	{
		startNode = gridManager.TryGetNode(startCoordinates);
		destinationNode = gridManager.TryGetNode(destinationCoordinates);
		currentSearchNode = startNode;
		BreadthFirstSearch();
	}


	void BreadthFirstSearch()
	{
		bool isRunning = true;

		frontier.Enqueue(currentSearchNode);
		reached.Add(startCoordinates, currentSearchNode);

		while (frontier.Count > 0 && isRunning)
		{
			currentSearchNode = frontier.Dequeue();
			currentSearchNode.isExplored = true;
			ExploreNeighbors();
			if (currentSearchNode.coordinates == destinationCoordinates)
			{
				isRunning = false;
			}
		}
	}


	void ExploreNeighbors()
	{
		List<Node> neighbors = new List<Node>();

		foreach (Vector2Int direction in DIRECTIONS)
		{
			Node neighbor = gridManager.TryGetNode(currentSearchNode.coordinates + direction);

			if (neighbor != null)
			{
				neighbors.Add(neighbor);
				neighbor.isExplored = true;
				currentSearchNode.isPath = true;
			}
		}

		foreach (Node neighbor in neighbors)
		{
			if (!reached.ContainsKey(neighbor.coordinates) && neighbor.isWalkable)
			{
				reached.Add(neighbor.coordinates, neighbor);
				frontier.Enqueue(neighbor);
			}
		}
	}
}
