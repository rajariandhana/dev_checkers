using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    // public Image white, black;
    public RectTransform grid;
    public Tile pref_tile;
    // public Sprite white, black;

    // public Tile tilePrefab;
    // public int row, col;

    private bool isWhite=true;

    private void Start() {
        // GenerateGrid();
    }

    public void GenerateGrid()
    {
        for(int i=0; i<8; i++)
        {
            for(int j=0; j<8; j++)
            {
                Tile spawned = Instantiate(pref_tile);
                spawned.isWhite = isWhite;
                spawned.transform.SetParent(grid);

                spawned.row = i;
                spawned.col = j;

                isWhite = !isWhite;
            }
            isWhite = !isWhite;
        }
    }
}
