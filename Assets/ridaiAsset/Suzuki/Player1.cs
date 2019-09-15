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

    //　レイを飛ばす位置
    [SerializeField]
    private Transform rayPosition;
    //　レイの距離
    [SerializeField]
    private float rayRange = 0.6f;

    // Start is called before the first frame update
    void Start()
    { 
       rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*キーを受け取って、何か呼び出す
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        {
            if (playerStatus.footOn)
            {
                PlMove(Vector3.up*jumpPow,rb);
            }

        }

        if (Input.GetKey(KeyCode.D))
        {
            PlMove(Vector3.right * 25, rb);
        }


        if (Input.GetKey(KeyCode.A))
        {
            PlMove(Vector3.left * 25, rb);
        }*/

        //落ちた時の処理
        if (this.transform.position.y < -25)
        {
           // Gamerule.Miss();
        }

        //接地状態の確認
        if (Physics.Linecast(rayPosition.position, (rayPosition.position - transform.up * rayRange))) 
        {
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
        direction = GameObject.Find("GameRule").GetComponent<KeyChecker>().direction;
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
        GameObject.Find("GameRule").GetComponent<ContactDeal>().Touch(playerStatus,false);
    }
    void OnCollisionExit()
    {
        playerStatus.SetTouchCol(null);
    }

    //移動に使うメソッド　なんかこの形式ではない気がする
    void PlMove(Vector3 direction,Rigidbody rigidbody)
    {
            rigidbody.AddForce(direction);
    }

}
