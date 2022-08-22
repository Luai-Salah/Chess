using System;
using System.Collections.Generic;
using UnityEngine;

public class PieceCreator : MonoBehaviour
{
	[SerializeField] private Transform[] piecesPrefabs;
	[SerializeField] private Material blackMaterial;
	[SerializeField] private Material whiteMaterial;

	private Dictionary<string, Transform> nameToPieceDic = new Dictionary<string, Transform>();

	private void Awake()
	{
		foreach (Transform _transform in piecesPrefabs)
			nameToPieceDic.Add(_transform.GetComponent<Piece>().GetType().ToString(), _transform);
	}

	public Transform CreatePiece(Type _type)
	{
		Transform prefab = nameToPieceDic[_type.ToString()];
		if (prefab)
		{
			Transform _newPiece = Instantiate(prefab);
			return _newPiece;
		}

		return null;
	}

	public Material GetTeamMaterial(TeamColor team)
	{
		return team == TeamColor.White ? whiteMaterial : blackMaterial;
	}
}