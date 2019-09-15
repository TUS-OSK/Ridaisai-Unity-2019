using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ContactDeal : MonoBehaviour
{

    public void Touch(PlayerStatus playerStatus,bool step)
    {
        string touchTag;

        if(playerStatus.GetTouchCol() != null)
        {
            touchTag = playerStatus.GetTouchCol().gameObject.tag;
        }
        else//playerStatusのTouchColがnullの時の処理
        {
            touchTag = "";
        }

        switch (touchTag)
        {
            case "Nokonoko":
                if (step)
                {
                    //ノコノコを踏んだ時の処理
                    Debug.Log("nokokick");
                    //Destroy(playerStatus.touchCol.gameObject);
                    playerStatus.SetTouchCol(null);
                }
                else
                {
                    //ノコノコに当たった時の処理
                    Debug.Log("noko");
                }
                break;

            case "Goal":
                //ゴールに当たった時の処理     
                Debug.Log("Goal!");
                break;

            case "Item":
                //アイテムに当たった時の処理
                break;

            default:break;
        }

    }
}
