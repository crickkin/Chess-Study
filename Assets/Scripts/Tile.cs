using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]private int cellID;

    public void SetCellID(int cellID)
    {
        this.cellID = cellID;
    }

    public int GetCell()
    {
        return cellID;
    }
}
