using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ContactDeal : MonoBehaviour
{

    public float star;

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
                if (step||(star > 0))
                {
                    //ノコノコを踏んだ時の処理

                    Debug.Log("nokokick");
                    playerStatus.GetTouchCol().gameObject.GetComponent<Enemy01>().EnemyDeath();
                    playerStatus.SetTouchCol(null);

                    //一瞬無敵にする
                    if(star <= 1){
                        star = 1;
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

            case "Item":
                //アイテムに当たった時の処理
                star = 30.0f;
                break;

            default:break;
        }

    }

    void Update(){
        //無敵時間をカウントダウンする
        if(star > 0){
        star -= Time.deltaTime;
        }
        else{
            star = 0;
        }
    }
}
