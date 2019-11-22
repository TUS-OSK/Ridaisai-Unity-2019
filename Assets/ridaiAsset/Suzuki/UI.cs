using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{


    public int zanki;
    public Text Lifes;
    public Text State;


    // Start is called before the first frame update
    void Start()
    {
        Lifes.text = "Life × " + zanki;
        DisplayState("GameStart!!",3.0f);
    }

    public void DisplayState(string str,float flo){
        State.text = str;
        Invoke("Ilase", flo);
    }

    public void Ilase (){
        State.text = "";
    }

    public void Miss(){
        zanki --;
        Lifes.text = "Life × " + zanki;
        DisplayState("Miss...",3.0f);
    }
}