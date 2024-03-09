using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    // public Image white, black;
    public static Grid instance;
    public RectTransform rt;
    public Tile pref_tile;
    // public Sprite white, black;

    // public Tile tilePrefab;
    // public int row, col;

    private bool isWhite=true;

    public Tile[,] arr;

    public void GenerateGrid()
    {
        for(int i=0; i<8; i++)
        {
            for(int j=0; j<8; j++)
            {
                Tile spawned = Instantiate(pref_tile);
                spawned.isWhite = isWhite;
                spawned.transform.SetParent(rt);

                spawned.row = i;
                spawned.col = j;
                spawned.name = $"Tile {i} {j}";

                arr[i,j] = spawned;

                isWhite = !isWhite;
            }
            isWhite = !isWhite;
        }
    }
    void Start()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
        arr = new Tile[8,8];
    }
}
