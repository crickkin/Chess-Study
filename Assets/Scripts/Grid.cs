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
                Debug.Log($"Grid ({gridCell.x}, {gridCell.y})");
                Debug.Log($"PosX: {gridCell.position.x} \tPosY: {gridCell.position.y}");
            }
        }
    }
}
