using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gamerule : MonoBehaviour
{

    public int zanki;
    public Text Text;
    public Text news;
    

    // Start is called before the first frame update
    void Start()
    {
        Text.text = "Life × " + zanki;
        news.text = "Gamestart!";
        Invoke("Ilase", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Miss()
    {
        GameObject player;

        player= GameObject.Find("player");
        player.transform.position = Vector3.up * 2;

        zanki--;
        Text.text = "Life ×" + zanki;
        news.text = "Miss!";
        Invoke("Ilase", 3);

        if (zanki  == 0)
        {
            //ゲームオーバー処理
        }
        
    }

    public void Touch(Collision col)
    {
       if (col.gameObject.CompareTag("Nokonoko"))
        {
            //ノコノコに当たった時の処理
            Debug.Log("noko");
            Miss();
        }
        /*if (col.gameObject.CompareTag("Item"))
        {
            //アイテムに当たった時の処理
            Debug.Log("Item");
        }*/
        if (col.gameObject.CompareTag("Goal"))
        {
            //ゴールに当たった時の処理
            Debug.Log("Goal!");
            news.text = "Goal!";
            
        }
    }

    public int Touch(Collider col)
    {
        if (col.gameObject.CompareTag("Nokonoko"))
        {
            //ノコノコを踏んだ時の処理
            Debug.Log("nokokick");
            Destroy(col.gameObject);
            return 2;

        }
        /*if (col.gameObject.CompareTag("Item"))
        {
            //アイテムを踏んだ時の処理
            Debug.Log("Item");
        }*/
        if (col.gameObject.CompareTag("Goal"))
        {
            //ゴールを踏んだ時の処理
            Debug.Log("Goal!");
            news.text = "Goal!";
            
        }

        
        return 1;
    }

  
    private void Ilase()
    {
        news.text = "";
    }




}
