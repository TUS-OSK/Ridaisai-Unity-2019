using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    GameObject ui;
    ScoreText a;
    public Text score;
    // Start is called before the first frame update
    void Start()
    {
        //ui = GameObject.Find("UIDealer");
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score" + ScoreText.point;
    }
}
