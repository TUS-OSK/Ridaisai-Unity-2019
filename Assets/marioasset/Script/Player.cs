using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float jump;
    public int speedgap;

    private GameObject foot; //objectそのものが入る変数
    private GameObject obGamerule;


    private Footcheck script; //Scriptが入る変数
    private Gamerule Gamerule;

    // Start is called before the first frame update
    void Start()
    {

        rb = this.GetComponent<Rigidbody>();
        foot = GameObject.Find("foot"); //オブジェクトの名前から取得して変数に格納する
        script = foot.GetComponent<Footcheck>(); //objectの中にあるScriptを取得して変数に格納する

        obGamerule = GameObject.Find("GameRule");
        Gamerule = obGamerule.GetComponent<Gamerule>();

    }

    // Update is called once per frame
    void Update()
    {

        //速度を制限してる
        if ((rb.velocity.x) > speedgap)
        {
            rb.velocity = Vector3.up * rb.velocity[1] + Vector3.right * speedgap;
        }
        if ((rb.velocity.x) < -speedgap)
        {
            rb.velocity = Vector3.up * rb.velocity[1] + Vector3.right * -speedgap;
        }
        //落ちた時の処理
        if (this.transform.position.y < -20)
        {
            Gamerule.Miss();
        }
    }

    void FixedUpdate()
    {

        int footing = script.footon;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        {
            if (footing >= 1)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    rb.AddForce(transform.up * jump, ForceMode.Impulse);
                }
                else
                {
                    rb.AddForce(transform.up * jump * 0.7f, ForceMode.Impulse);
                }

            }

        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * 25);
        }


        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(transform.right * -25);
        }

    }

    void OnCollisionEnter(Collision col)//is Triggerでないのを想定
    {
        int footing = script.footon;
        if (footing != 2)
        {
            Gamerule.Touch(col);
        }

    }
}