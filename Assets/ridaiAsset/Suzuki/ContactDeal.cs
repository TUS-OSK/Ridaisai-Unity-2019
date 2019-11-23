using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ContactDeal : MonoBehaviour
{

    public float starTime;
    public GameObject UiObject;
    public UI UiScript;

    void Start(){
        UiObject = GameObject.Find("UIDealer");
        UiScript= UiObject.GetComponent<UI>();
    }

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

                    //Debug.Log("nokokick");
                    playerStatus.GetTouchCol().gameObject.GetComponent<Enemy01>().EnemyDeath();
                    playerStatus.SetTouchCol(null);

                    //destroyには若干ラグがある

                    //一瞬無敵にする
                    if(starTime<= 1){
                        starTime = 1;
                    }
                    //音鳴らす
                    UiObject.GetComponent<JukeBox>().JukeBoxOn("hunda");
                }
                else
                {
                    //ノコノコに当たった時の処理
                    //Debug.Log("noko");
                    if(!(GetComponent<Savepoint>().respowning))
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
                    starTime = 10.0f;
                    UiScript.DisplayState("POWER UP!!",10.0f);
                    break;

                    case EnumTag.icon:
                    Debug.Log("ok");
                    GetComponent<KeyChecker>().JumpUp(5.0f);
                    UiScript.DisplayState("JUMP UP!!",5.0f);
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
