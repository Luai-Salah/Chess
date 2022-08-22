using UnityEngine;

[CreateAssetMenu(fileName ="New Board Layout", menuName ="Board/Layout")]
public class BoardLayout : ScriptableObject
{
    [System.Serializable]
    private class BoardSquareSetup
    {
        public Vector2Int position;
        public PieceType pieceType;
        public TeamColor teamColor;
    }

    [SerializeField] private BoardSquareSetup[] boardSquare;

    public int piecesCount { get { return boardSquare.Length; } }

    public Vector2Int GetSquareCoordsAtIndex(int _index)
    {
        if (boardSquare.Length <= _index)
        {
            Debug.LogError("Index of piece is out of range", this);
            return new Vector2Int(-1, -1);
        }

        return new Vector2Int(boardSquare[_index].position.x - 1, boardSquare[_index].position.y - 1);
    }

    public string GetSquarePieceNameAtIndex(int _index)
    {
        if (boardSquare.Length < _index)
        {
            Debug.LogError("Index of piece is out of range", this);
            return PieceType.UNKNOWN.ToString();
        }

        return boardSquare[_index].pieceType.ToString();
    }

    public TeamColor GetSquareTeamColorAtIndex(int _index)
    {
        if (boardSquare.Length < _index)
        {
            Debug.LogError("Index of piece is out of range", this);
            return TeamColor.UNKNOWN;
        }

        return boardSquare[_index].teamColor;
    }
}