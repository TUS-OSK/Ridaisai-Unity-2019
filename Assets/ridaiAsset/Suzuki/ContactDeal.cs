using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ContactDeal : MonoBehaviour
{

    public float starTime;

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
                if (step||(starTime > 0))
                {
                    //ノコノコを踏んだ時の処理

                    Debug.Log("nokokick");
                    playerStatus.GetTouchCol().gameObject.GetComponent<Enemy01>().EnemyDeath();
                    playerStatus.SetTouchCol(null);

                    //destroyには若干ラグがある

                    //一瞬無敵にする
                    if(starTime<= 1){
                        starTime = 1;
                    }
                }
                else
                {
                    //ノコノコに当たった時の処理
                    //Debug.Log("noko");
                    GetComponent<Savepoint>().Respown();
                }
                break;

            case "Goal":
                //ゴールに当たった時の処理     
                Debug.Log("Goal!");
                break;

            case "Star":
                //アイテムに当たった時の処理

                switch(playerStatus.GetTouchCol().gameObject.GetComponent<ItemEnum>().kind){
                    case EnumTag.star:
                    starTime = 30.0f;
                    break;

                    case EnumTag.icon:
                    Debug.Log("icon");
                    break;

                    default:break; 
                }
                break;

            default:break;
        }

    }

    void Update(){
        //無敵時間をカウントダウンする
        if(starTime > 0){
        starTime -= Time.deltaTime;
        }
        else{
            starTime = 0;
        }
    }
}
