using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour
{
    //GameRuleからの色々な情報を処理するプログラム
    //jumpPowなどpublicになってる変数で適宜調整する

    private Rigidbody rb;
    public float jumpPow;
    public float speedgap;

    public PlayerStatus playerStatus = new PlayerStatus(null ,true);

    private bool stumpready;

    //　レイを伸ばして接地判定に用いる
    [SerializeField]
    private Transform rayPosition;
    //　レイの距離
    [SerializeField]
    public float rayRange = 0.6f;

    // Start is called before the first frame update
    void Start()
    { 
       rb = this.GetComponent<Rigidbody>();
       stumpready = false;

    }

    // Update is called once per frame
    void Update()
    {

        //落ちた時の処理
        if (this.transform.position.y < -25)
        {
           // Gamerule.Miss();
        }

        //接地状態の確認
        if (Physics.Linecast(rayPosition.position, (rayPosition.position - transform.up * rayRange))) 
        {
            if(!playerStatus.GetFootOn())//空中から接地したら、踏む準備する
            {
                stumpready = true;
            }
            playerStatus.SetFootOn(true);
        }
        else
        {
            playerStatus.SetFootOn(false);
        }
        //　接地確認用にレイを視覚化
        Debug.DrawLine(rayPosition.position, (rayPosition.position - transform.up * rayRange), Color.red);
    }

    void FixedUpdate()
    {
        Vector3 direction;
        direction = GetComponent<KeyChecker>().direction;
        rb.AddForce(direction);

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

    //接触状態の監視
    void OnCollisionEnter(Collision col)//CollisionはCollider,GameObjectとか色々包括してる
    {
        playerStatus.SetTouchCol(col);
        //踏む準備ができているかどうかの情報と共にContactDealに渡す
        GetComponent<ContactDeal>().Touch(playerStatus,stumpready);
        stumpready = false;
    }
    void OnCollisionExit()
    {
        playerStatus.SetTouchCol(null);
    }

}
