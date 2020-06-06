using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GridCell
{
    public GameObject piece = null;
    public int x = 0;
    public int y = 0;

    public Vector2 position;

    public GridCell(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public void SetPosition(Vector2 position)
    {
        this.position = position;
    }
}

public class Grid : MonoBehaviour
{
    public GameObject board;
    public GameObject piece;

    public const int gridSize = 8;
    private int cellSize = 1;

    private static Grid script;
    
    private GridCell[,] gridCells = new GridCell[gridSize, gridSize];

    void Start()
    {
        if (script == null)
        {
            script = this;
        }
        else if (script != this)
        {
            Destroy(gameObject);
        }

        CreateGrid();
        Instantiate(board, transform.position, Quaternion.identity);
    }

    public static Grid GetGrid()
    {
        return script;
    }

    void CreateGrid()
    {
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                GridCell gridCell = new GridCell(i, j);
                gridCells[i, j] = gridCell; 
            }
        }
    }

    public GridCell GetGridCell(int x = 0, int y = 0)
    {
        GridCell gridCell = gridCells[x, y];
        return gridCell;
    }

    public void CreatePieces()
    {
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                GameObject pieceObject = Instantiate(this.piece, gridCells[i, (6 + j)].position, Quaternion.identity);
                gridCells[i, (6 + j)].piece = pieceObject;
                Piece pieceComponent = pieceObject.GetComponent<Piece>();
                if (j == 1)
                {
                    if (i == 0 || i == 7)
                        pieceComponent.pieceType = Piece.PieceType.Tower;
                    else if (i == 1 || i == 6)
                        pieceComponent.pieceType = Piece.PieceType.Knight;
                    else if (i == 2 || i == 5)
                        pieceComponent.pieceType = Piece.PieceType.Bishop;
                    else if (i == 3)
                        pieceComponent.pieceType = Piece.PieceType.Queen;
                    else if (i == 4)
                        pieceComponent.pieceType = Piece.PieceType.King;
                }
            }
        }

    }


    // DEBUG
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ShowGridInfo();
        }
    }

    private void ShowGridInfo()
    {
        GridCell gridCell;
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                gridCell = gridCells[i, j];
                if (gridCell.piece != null)
                {
                    Debug.Log($"Grid ({gridCell.x}, {gridCell.y})");
                    Debug.Log($"PosX: {gridCell.position.x} \tPosY: {gridCell.position.y}");
                    Debug.Log(gridCell.piece);
                }
            }
        }
    }
}
