using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public static Controller instance;
    // public Grid grid;
    private bool playerTurn = true;
    public Piece cur_piece;
    public Piece pref_piece;
    // public Sprite light_plain, dark_plain, light_king, dark_king;
    // public Sprite tile_white, tile_black;
    public GameObject Panel_win;
    public GameObject turn;
    // public Tile cur_tile;
    public bool GetTurn()
    {
        return playerTurn;
    }
    public void ChangeTurn()
    {
        playerTurn = !playerTurn;
        Text val = turn.GetComponent<Text>();
        val.text = playerTurn? "Blue's turn":"Red's turn";
        CheckWin();
    }
    private void CheckWin()
    {
        if(PieceManager.instance.num_piece_player==0 || PieceManager.instance.num_piece_opponent==0)
        {
            Text val = Panel_win.GetComponentInChildren<Text>();
            val.text = PieceManager.instance.num_piece_opponent==0? "Blue Win":"Red Win";
            Panel_win.SetActive(true);
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
        playerTurn = true;

        Grid.instance.GenerateGrid();
        PieceManager.instance.SpawnStartingPiece();
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Game");
    }

}
