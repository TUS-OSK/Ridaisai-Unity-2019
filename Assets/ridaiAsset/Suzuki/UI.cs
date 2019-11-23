using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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
        if(zanki == 0){
            SceneManager.LoadScene("Score");
        } 
        Lifes.text = "Life × " + zanki;
        DisplayState("Miss...",3.0f);
    }
}