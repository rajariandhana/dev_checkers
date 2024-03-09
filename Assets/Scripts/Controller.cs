using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public static Controller instance;
    // public Grid grid;
    private bool playerTurn = true;
    public Piece cur_piece;
    public Piece pref_piece;
    public Sprite light_plain, dark_plain, light_king, dark_king;
    public Sprite tile_white, tile_black;
    // public Tile cur_tile;
    public bool GetTurn()
    {
        return playerTurn;
    }
    public void ChangeTurn()
    {
        playerTurn = !playerTurn;
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
        playerTurn = true;

        Grid.instance.GenerateGrid();
        SpawnPiece();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Setup()
    {
        
    }
    public void SpawnPieceLama()
    {
        // for (int i = 0; i < grid.transform.childCount; i++)
        // {
        //     GameObject childObject = parentObject.transform.GetChild(i).gameObject;
        // }
        for(int i=1; i<24; i+=2)
        {
            if(i==9) {i=6; continue;}
            if(i==16) {i=15; continue;}
            GameObject childObject = Grid.instance.transform.GetChild(i).gameObject;
            Tile tile = childObject.GetComponent<Tile>();
            Spawn(tile,false,false);
        }
        for(int i=40; i<64; i+=2)
        {
            if(i==48) {i=47; continue;}
            if(i==57) {i=54; continue;}
            GameObject childObject = Grid.instance.transform.GetChild(i).gameObject;
            Tile tile = childObject.GetComponent<Tile>();
            Spawn(tile,true,false);
        }
    }
    public void SpawnPiece()
    {
        for(int i=0; i<3; i++)
        {
            int js = i%2==0 ? 1 : 0;
            int je = i%2==0 ? 7 : 6;
            for(int j=js; j<=je; j+=2)
            {
                Tile tile = Grid.instance.arr[i,j];
                Spawn(tile, false,false);
            }
        }

        for(int i=5; i<8; i++)
        {
            int js = i%2==0 ? 1 : 0;
            int je = i%2==0 ? 7 : 6;
            for(int j=js; j<=je; j+=2)
            {
                Tile tile = Grid.instance.arr[i,j];
                Spawn(tile, true,false);
            }
        }
    }
    public void Spawn(Tile tile, bool isPlayer, bool isKing)
    {
        Piece spawned = Instantiate(pref_piece);
        spawned.isPlayer = isPlayer;
        spawned.isKing = isKing;
        spawned.row = tile.row;
        spawned.col = tile.col;
        
        spawned.transform.SetParent(tile.GetComponent<RectTransform>());
    }
}
