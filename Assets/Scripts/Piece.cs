using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Piece : MonoBehaviour, IPointerClickHandler
{
    [HideInInspector] public Transform parentAfterDrag;
    public bool isPlayer, isKing;
    public int row, col;
    public bool GetType()
    {
        return isPlayer;
    }
    public void OnPointerClick(PointerEventData ped)
    {
        // Piece pc = ped.GetComponent<Piece>();
        if(Controller.instance.GetTurn() == isPlayer)
        {
            Debug.Log("Piece clicked "+Data());
            Controller.instance.cur_piece = this;
        }
    }
    private void Start() {
        Image im = GetComponent<Image>();
        if(isPlayer) im.sprite = PieceManager.instance.dark_plain;
        else im.sprite = PieceManager.instance.light_plain;
    }
    public void ChangePieceType()
    {
        if(isPlayer && row==0)
        {
            isKing = true;
            Image im = GetComponent<Image>();
            im.sprite = PieceManager.instance.dark_king;
        }
        if(!isPlayer && row==7)
        {
            isKing = true;
            Image im = GetComponent<Image>();
            im.sprite = PieceManager.instance.light_king;
        }
    }

    public string Data()
    {
        string res="";
        if(isPlayer) res+="player";
        else res+="opponent";

        if(isKing) res+=" king";
        else res+=" plain";
        return res;
    }
}
