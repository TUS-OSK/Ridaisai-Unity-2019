using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpPow;
    public int speedgap;

    public PlayerStatus playerStatus = new PlayerStatus(null ,true);

    // Start is called before the first frame update
    void Start()
    { 
       rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // kokorahenn ni sousa wo kaiteku
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        {
            if (playerStatus.footOn)
            {
                PlJump(jumpPow,rb);
            }

        }

        if (Input.GetKey(KeyCode.D))
        {
            PlMove(Vector3.right * 25, playerStatus.footOn,rb);
        }


        if (Input.GetKey(KeyCode.A))
        {
            PlMove(Vector3.left * 25, playerStatus.footOn,rb);
        }

        //落ちた時の処理
        if (this.transform.position.y < -25)
        {
           // Gamerule.Miss();
        }

     }

    void FixedUpdate()
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


    }

    void OnCollisionEnter(Collision col)//subete no object wo soutei
    {
        playerStatus.touchCol = col;
        GameObject.Find("GameRule").GetComponent<ContactDeal>().Touch(playerStatus,false);
    }

    void OnCollisionExit()
    {
        playerStatus.touchCol = null;
    }


    void PlMove(Vector3 direction,bool FootOn,Rigidbody rigidbody)
    {
           
        if (FootOn)
        {
            rigidbody.AddForce(direction);
        }
        else
        {
            rigidbody.AddForce(direction * 0.6f);
        }
    }

    void PlJump(float pow,Rigidbody rigidbody)
    {
        rigidbody.AddForce(Vector3.up * pow,ForceMode.Impulse);
    }

}
