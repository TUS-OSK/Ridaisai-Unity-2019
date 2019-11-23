using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text score;
    static public float point;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //score.text = "Score" + point;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 d = player.transform.position;
        point = d.x+0.181f;
        score.text = "Score" + point;
    }
     public float Score()
    {
        return point;
    }
}
