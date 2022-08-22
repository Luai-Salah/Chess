using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IObjectTweener))]
[RequireComponent(typeof(MaterialSetter))]
public abstract class Piece : MonoBehaviour
{
	private MaterialSetter mSetter;

	public Board Board { protected get; set; }
	public Vector2Int OccupiedSquare { get; set; }
	public TeamColor Team { get; set; }
	public bool HasMoved { get; private set; }

	public List<Vector2Int> AvailableMoves;

	private IObjectTweener tweener;

	public abstract List<Vector2Int> SelectAvailableSqueres();

	private void Awake()
	{
		AvailableMoves =  new List<Vector2Int>();
		tweener = GetComponent<IObjectTweener>();
		mSetter = GetComponent<MaterialSetter>();
		HasMoved = false;
	}

	public void SetMaterial(Material mat)
	{
		if (mSetter == null)
			mSetter = GetComponent<MaterialSetter>();
		mSetter.SetSingleMaterial(mat);
	}

	public bool IsFromSameTeam(Piece _piece)
	{
		return _piece.Team == Team;
	}

	public void SetData(Vector2Int squareCoords, TeamColor team, Board board)
	{
		Team = team;
		Board = board;
		OccupiedSquare = squareCoords;
		transform.position = Board.CalculatePositionFromCoords(squareCoords);
	}

	public bool CanMoveTo(Vector2Int coords)
	{
		return AvailableMoves.Contains(coords);
	}

	protected void TryToAddMove(Vector2Int coords)
	{
		AvailableMoves.Add(coords);
	}

	public virtual void MovePiece(Vector2Int coords)
	{

	}
}