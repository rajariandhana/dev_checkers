using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PieceManager : MonoBehaviour
{
    public static PieceManager instance;
    [SerializeField] public int num_piece_player;
    [SerializeField] public int num_piece_opponent;
    // [SerializeField] private int eaten_piece_player;
    // [SerializeField] private int eaten_piece_opponent;
    public GameObject eaten_player, eater_opponent;

    void Start()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
        // eaten_piece_player=0;
        // eaten_piece_opponent=0;
    }

    public Piece pref_piece;
    public Sprite light_plain, dark_plain, light_king, dark_king;

    public void SpawnStartingPiece()
    {
        // StartCoroutine(Wait(10.0f));
        for(int i=0; i<3; i++)
        {
            int js = i%2==0 ? 1 : 0;
            int je = i%2==0 ? 7 : 6;
            for(int j=js; j<=je; j+=2)
            {
                Tile tile = Grid.instance.arr[i,j];
                SpawnPiece(tile, false);
            }
        }

        for(int i=5; i<8; i++)
        {
            int js = i%2==0 ? 1 : 0;
            int je = i%2==0 ? 7 : 6;
            for(int j=js; j<=je; j+=2)
            {
                Tile tile = Grid.instance.arr[i,j];
                SpawnPiece(tile, true);
            }
        }
    }
    IEnumerator Wait(float x)
    {
        yield return new WaitForSeconds(x);
    }
    public void SpawnPiece(Tile tile, bool isPlayer)
    {
        // Piece spawned = tile.GetComponentInChildren<Piece>();
        // StartCoroutine(Wait(1.0f));
        Piece spawned = Instantiate(pref_piece);
        spawned.isPlayer = isPlayer;
        spawned.row = tile.row;
        spawned.col = tile.col;
        if(isPlayer) num_piece_player++;
        else num_piece_opponent++;
        
        spawned.transform.SetParent(tile.GetComponent<RectTransform>());
        spawned.transform.position = tile.transform.position;
    }
    public void DeletePiece(Piece pc)
    {
        if(pc.isPlayer) num_piece_player--;
        else num_piece_opponent--;
        Destroy(pc.gameObject);
        UpdateEaten();
    }
    private void UpdateEaten()
    {
        Text player = eaten_player.GetComponentInChildren<Text>();
        player.text = (12-num_piece_player).ToString();
        Text opponent = eater_opponent.GetComponentInChildren<Text>();
        opponent.text = (12-num_piece_opponent).ToString();
    }
}
