using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Piece : MonoBehaviour
{
    public static Manager_Piece instance;
    [SerializeField] public int num_piece_player;
    [SerializeField] public int num_piece_opponent;
    [SerializeField] public int eaten_piece_player;
    [SerializeField] public int eaten_piece_opponent;

    void Start()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
        eaten_piece_player=0;
        eaten_piece_opponent=0;
    }

    public Piece pref_piece;
    public Sprite light_plain, dark_plain, light_king, dark_king;

    public void SpawnStartingPiece()
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
        if(isPlayer) num_piece_player++;
        else num_piece_opponent++;
        
        spawned.transform.SetParent(tile.GetComponent<RectTransform>());
    }
}
