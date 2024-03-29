﻿using UnityEngine;

public class Board : MonoBehaviour
{
	[SerializeField] private Transform bottmLeftSquare;
	[SerializeField] private float squareSize;

	public Vector3 CalculatePositionFromCoords(Vector2Int coords)
	{
		return bottmLeftSquare.position + new Vector3(coords.x * squareSize, 0f, coords.y * squareSize);
	}
}