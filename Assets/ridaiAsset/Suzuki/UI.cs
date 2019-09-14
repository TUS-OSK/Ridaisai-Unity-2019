using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{


    public int zanki;
    public Text Lifes;
    public Text news;


    // Start is called before the first frame update
    void Start()
    {
        Lifes.text = "Life × " + zanki;
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

        player = GameObject.Find("player");
        player.transform.position = Vector3.up * 2;

        zanki--;
        Lifes.text = "Life ×" + zanki;
        news.text = "Miss!";
        Invoke("Ilase", 3);

        if (zanki == 0)
        {
            //ゲームオーバー処理
        }

    }


    private void Ilase()
    {
        news.text = "";
    }
}