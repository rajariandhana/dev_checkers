using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Piece : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] public Transform parentAfterDrag;
    public bool isPlayer, isKing;
    public int row, col;
    public bool GetType()
    {
        return isPlayer;
    }
    
    private void Start() {
        Image im = GetComponent<Image>();
        if(isPlayer) im.sprite = PieceManager.instance.dark_plain;
        else im.sprite = PieceManager.instance.light_plain;
    }
    /*
    tile 3
    di game, parent tile gw pindahin, anchor middle, bisa debuglog
    dibalikin ke tile lama, ga bisa

    aight jadi ternyata 3 piece itu bisa diklik tapi harus
    di ujung kanan mereka, masalah hitbox?
    */
   public  Transform oriParent;
    public Vector3 oriPos;
    // Tile oriTile;
    // public void OnPointerClick(PointerEventData ped)
    // {
    //     Debug.Log("cl");
    //     // Piece pc = ped.GetComponent<Piece>();
    //     if(Controller.instance.GetTurn() == isPlayer)
    //     {
    //         Debug.Log(Data());
    //         Controller.instance.cur_piece = this;
    //     }
    // }
    public void OnBeginDrag(PointerEventData ped)
    {
        Debug.Log(Data());
        
        if(Controller.instance.GetTurn() == isPlayer)
        {
            Controller.instance.cur_piece = this;
        }
        oriPos = transform.position;
        oriParent = transform.parent;
        transform.SetParent(transform.root);
        GetComponent<Image>().raycastTarget = false;
        return;
        
        // oriTile = transform.parent.GetComponent<Tile>();
    }

    public void OnDrag(PointerEventData ped)
    {
        transform.position = Input.mousePosition;
        // transform.position = Controller.instance.GetTurn() == isPlayer ? Input.mousePosition : oriPos;
    }

    public void OnEndDrag(PointerEventData ped)
    {
        // canvasGroup.blocksRaycasts = true;
        GetComponent<Image>().raycastTarget = true;
        transform.position = oriPos;
        transform.SetParent(oriParent);
        // if(transform.parent.GetComponent<Tile>()==oriParent)
        // {
        //     transform.position = oriPos;
        // }
        // if(transform.parent.GetComponent<Tile>() == transform.root)
        // {
        //     transform.SetParent(oriParent);
        //     transform.position = oriPos;
        // }
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
