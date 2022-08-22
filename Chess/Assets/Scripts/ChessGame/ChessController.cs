using System;
using UnityEngine;

[RequireComponent(typeof(PieceCreator))]
public class ChessController : MonoBehaviour
{
	[SerializeField] private Board board;
    [SerializeField] private BoardLayout boardLayout;

    private PieceCreator pCreator;

    private void Start()
    {
        SetDependencies();
        StartNewGame();
    }

	private void SetDependencies()
	{
		pCreator = GetComponent<PieceCreator>();
	}

	private void StartNewGame()
    {
        CreatePiecesFromLayout(boardLayout);
    }

	private void CreatePiecesFromLayout(BoardLayout _layout)
	{
		for (int i = 0; i < _layout.piecesCount; i++)
		{
            Vector2Int squareCoords = _layout.GetSquareCoordsAtIndex(i);
            TeamColor team = _layout.GetSquareTeamColorAtIndex(i);
            string typeName = _layout.GetSquarePieceNameAtIndex(i);

            Type type = Type.GetType(typeName);

            CreatePieceAndInitialize(squareCoords, team, type);
		}
	}

	private void CreatePieceAndInitialize(Vector2Int _squareCoords, TeamColor _team, Type _type)
	{
		Piece _newPiece = pCreator.CreatePiece(_type).GetComponent<Piece>();
		_newPiece.SetData(_squareCoords, _team, board);

		Material teamMat = pCreator.GetTeamMaterial(_team);
		_newPiece.SetMaterial(teamMat);
	}
}