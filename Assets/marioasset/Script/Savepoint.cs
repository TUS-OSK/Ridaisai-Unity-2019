using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Savepoint : MonoBehaviour
{
    float border2 = 2.4f;
    public GameObject UiObject;
    public UI UiScript;

    public bool respowning = false;

    void Start(){
        UiObject = GameObject.Find("UIDealer");
        UiScript= UiObject.GetComponent<UI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < border2)
        {
            if (transform.position.y < -12f)
            {
                UiObject.GetComponent<JukeBox>().JukeBoxOn("fall");
                if(!respowning)
                    Respown();
            }
        }
        if (transform.position.x > border2)
        {
            border2 += 2.675f;
        }

    }
    void LateUpdate(){
        respowning = false;
    }

    public void Respown(){
        respowning = true;
        UiScript.Miss();
        Vector3 save = new Vector3(border2 - 2.381f, 0.5f, 0);
        transform.position = save;
    }
}
