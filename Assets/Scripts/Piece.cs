using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Piece : MonoBehaviour, IPointerClickHandler
{
    [HideInInspector] public Transform parentAfterDrag;
    public bool isPlayer;
    public bool isKing;
    public bool GetType()
    {
        return isPlayer;
    }
    public void OnPointerClick(PointerEventData ped)
    {
        // Piece pc = ped.GetComponent<Piece>();
        Debug.Log("Piece clicked "+Data());
        if(Controller.instance.GetTurn() == isPlayer)
        {
            Controller.instance.cur_piece = this;
        }
    }
    private void Start() {
        Image im = GetComponent<Image>();
        if(isPlayer) im.sprite = Controller.instance.dark_plain;
        else im.sprite = Controller.instance.light_plain;
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
