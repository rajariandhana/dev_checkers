using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
            if(transform.childCount==0)
            {
                Controller.instance.cur_piece.transform.SetParent(GetComponent<RectTransform>());
                Controller.instance.cur_piece.transform.position = transform.position;
                Debug.Log(Controller.instance.cur_piece.Data() + " moved to "+row+" "+col);
                // Controller.instance.cur_piece.transform.SetParent(transform);
                Controller.instance.cur_piece = null;
                Controller.instance.ChangeTurn();
            }
        }
    }
    private void Start() {
        Image im = GetComponent<Image>();
        if(isWhite) im.sprite = Controller.instance.tile_white;
        else im.sprite = Controller.instance.tile_black;
    }
}
