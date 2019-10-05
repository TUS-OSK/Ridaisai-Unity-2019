using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyChecker : MonoBehaviour
{
    public Vector3 direction;

    public float jumpPow;
    public float movePow;
    public float decay;

    PlayerStatus playerStatus;

    private void Start()
    {
        playerStatus = GetComponent<Player1>().playerStatus;
    }

    // Update is called once per frame
    public void Check()
    {
        //一回初期化
        direction = Vector3.zero;

        //キーを受け取ってdirectionいじる
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        {
            if (playerStatus.footOn)
            {
                direction += Vector3.up * jumpPow;
            }

        }

        if (Input.GetKey(KeyCode.D))
        {
            if (playerStatus.footOn)
            {
                direction += Vector3.right * movePow;
            }
            else
            {
                direction += Vector3.right * movePow*decay;
            }
        }


        if (Input.GetKey(KeyCode.A))
        {
            if (playerStatus.footOn)
            {
                direction += Vector3.left * movePow;
            }
            else
            {
                direction += Vector3.left * movePow * decay;
            }
        }
        //多分これを良い実装にするにはインターフェースの知識が必要なんだろなぁ…
    }

    void Update()
    {
        Check();
    }

}
