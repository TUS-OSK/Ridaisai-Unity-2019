﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidJump : MonoBehaviour
{
    //変数定義
    public float flap = 5f;
    public float scroll = 10f;
    Rigidbody2D rb2d;


    // Use this for initialization
    void Start()
    {
        //コンポーネント読み込み
        rb2d = GetComponent<Rigidbody2D>();
    }
    float direction = 0f;//1から0へ変更

    bool jump = false;
    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = 1f;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = -1f;
        }
        else
        {
            direction = 0f;
        }
        //キャラのy軸のdirection方向にscrollの力をかける
        rb2d.velocity = new Vector2(scroll * direction, rb2d.velocity.y);
        if (Input.GetKeyDown("space") && !jump)
        {
            rb2d.AddForce(Vector2.up * flap);
            jump = true;
        }

    }
     void OnCollisionEnter2D(Collision2D col)
    {
        jump = false;
    }

}

