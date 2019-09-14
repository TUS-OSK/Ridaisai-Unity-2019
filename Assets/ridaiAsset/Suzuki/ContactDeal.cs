using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ContactDeal : MonoBehaviour
{



    public void Touch(PlayerStatus playerStatus,bool step)
    {
        string touchTag;

        touchTag = playerStatus.touchCol.gameObject.tag;
        //touchTag = GetTouchCol(playerStatus).touchCol.gameObject.tag; ga tabun tadashii

        if (touchTag == "Nokonoko")
        {
            if (step)
            {
                //ノコノコを踏んだ時の処理
                Debug.Log("nokokick");
                Destroy(playerStatus.touchCol.gameObject);
            }
            else
            {
                //ノコノコに当たった時の処理
                Debug.Log("noko");

            }
            /*if (col.gameObject.CompareTag("Item"))
            {
                //アイテムに当たった時の処理
                Debug.Log("Item");
            }*/
            if (touchTag == ("Goal"))
            {
                //ゴールに当たった時の処理
                Debug.Log("Goal!");
            }
        }
    }

}
