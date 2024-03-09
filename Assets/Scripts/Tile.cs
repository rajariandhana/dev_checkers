using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    public int row;
    public int col;
    public bool isWhite;
    // public Image image;
    // public Sprite sprite;
    public void OnPointerClick(PointerEventData ped)
    {
        if(Controller.instance.cur_piece != null)
        {
            Piece cur = Controller.instance.cur_piece;
            if(TileIsEmpty())
            {
                bool valid = cur.isKing ? KingValidMove(cur) : PlainValidMove(cur);
                if(valid)
                {
                    MovePiece(cur);
                    Controller.instance.cur_piece = null;
                    Controller.instance.ChangeTurn();
                }
            }
        }
    }
    private bool TileIsEmpty()
    {
        return transform.childCount==0? true : false;
    }
    /*
    plain player
    plain opponent
    king player
    king opponent
    */

    private bool PlainValidMove(Piece pc)
    {
        int absrow = Math.Abs(pc.row-row);
        int abscol = Math.Abs(pc.col-col);
        if((pc.isPlayer && row<pc.row) || (!pc.isPlayer && row>pc.row))
        {
            if(absrow==1 && abscol==1)
            {
                return true;
            }
            if(absrow==2 && abscol==2)
            {
                Tile t = Grid.instance.arr[(pc.row+row)/2,(pc.col+col)/2];
                return Eat(pc.isPlayer, t);
            }
        }
        return false;
    }
    private bool KingValidMove(Piece pc)
    {
        int absrow = Math.Abs(pc.row-row);
        int abscol = Math.Abs(pc.col-col);
        if(absrow==1 && abscol==1) return true;
        if(absrow==2 && abscol==2)
        {
            // int cekRow=pc.row;
            // int cekCol=pc.col;
            // if(row<pc.row) cekRow--;
            // else cekRow++;
            // if(col<pc.col) cekCol--;
            // else cekCol++;
            Tile t = Grid.instance.arr[(pc.row+row)/2,(pc.col+col)/2];
            return Eat(pc.isPlayer, t);
        }
        return false;
    }
    private bool Eat(bool pieceIsPlayer, Tile tile)
    {
        if(pieceIsPlayer != tile.GetComponentInChildren<Piece>().isPlayer)
        {
            Destroy(tile.GetComponentInChildren<Piece>().gameObject);
            //score++;
            Controller.instance.ChangeTurn();
            Debug.Log(pieceIsPlayer?"Player eat":"Opponent eat");
            return true;
        }
        return false;
    }
    private void MovePiece(Piece pc)
    {
        pc.transform.SetParent(GetComponent<RectTransform>());
        pc.transform.position = transform.position;
        pc.row = row;
        pc.col = col;
        Debug.Log(Controller.instance.cur_piece.Data() + " moved to "+row+" "+col);
    }
    private void Start() {
        Image im = GetComponent<Image>();
        if(isWhite) im.sprite = Controller.instance.tile_white;
        else im.sprite = Controller.instance.tile_black;
    }
}
