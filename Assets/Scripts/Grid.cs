using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    public static Grid instance;
    private void Start()
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
    public RectTransform rt;
    public Tile pref_tile;
    public Sprite tile_white, tile_black;

    private bool isWhite=true;

    public Tile[,] arr;

    public void GenerateGrid()
    {
        // for(int i=0; i<8; i++)
        // {
        //     for(int j=0; j<8; j++)
        //     {
        //         SpawnTile(isWhite,i,j);
        //         isWhite = !isWhite;
        //     }
        //     isWhite = !isWhite;
        // }
        int i=0;
        int j=0;
        foreach(Transform child in transform)
        {
            Tile x = child.GetComponent<Tile>();
            arr[i,j] = x;
            x.row = i;
            x.col = j;
            x.name = $"Tile {i} {j}";
            j++;
            if(j%8==0) {j=0; i++;}
            // if(i==8 || j==8) return;
        }
    }
    private void SpawnTile(bool isWhite, int row, int col)
    {
        Tile spawned = Instantiate(pref_tile);
        spawned.isWhite = isWhite;
        spawned.transform.SetParent(rt);

        spawned.row = row;
        spawned.col = col;
        spawned.name = $"Tile {row} {col}";

        arr[row,col] = spawned;
    }    
}
