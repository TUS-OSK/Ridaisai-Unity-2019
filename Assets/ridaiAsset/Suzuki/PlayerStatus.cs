using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus //: MonoBehaviour
{
    /*
 PlayerStatusの取説
 オブジェクトの触れている物、接地状態を入れられるクラス（増えるかも）
public PlayerStatus （名前） = new PlayerStatus(touchCol ,footOn); で新しく宣言できる
playerStatus.Get～()で要素の取り出し、playerStatus.Set～(~の値)で要素の変更ができる
 まあここまで言っといてなんだけどplayerでしか使わないので気にする必要はない
 */

    //field
    public Collision touchCol;
    public bool footOn;

        //method
    public PlayerStatus(Collision col1, bool boo)
       {
            touchCol = col1;
            //stepCol = col2;
            footOn = boo;
       }

    public Collision GetTouchCol()
        {
            return touchCol;
        }

     public void SetTouchCol(Collision newCol)
    {
        touchCol = newCol;
    }

    public bool GetFootOn()
        {
            return footOn;
        }

    public void SetFootOn(bool newFootOn)
    {
        footOn = newFootOn;
    }

}
