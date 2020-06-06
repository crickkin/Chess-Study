using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private int gridSize = Grid.gridSize;

    private Grid grid;

    [SerializeField] private GameObject tile;
    [SerializeField] private Sprite[] sprites;

    private static Board script;

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

        grid = Grid.GetGrid();
        CreateBoard();
    }

    void CreateBoard()
    {
        bool darkTile = false;

        for (int i=0; i < gridSize; i++)
        {
            for (int j=0; j < gridSize; j++)
            {
                GameObject tile = Instantiate(this.tile, transform);
                tile.transform.position = new Vector2((i+1) - (gridSize / 2), (gridSize/2) - j);
                tile.GetComponent<SpriteRenderer>().sprite = (darkTile) ? sprites[0] : sprites[1];

                GridCell gridCell = grid.GetGridCell(i, j);
                gridCell.SetPosition(tile.transform.position);

                darkTile = !darkTile;
            }
            darkTile = !darkTile;
        }
    }
}
