using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footcheck : MonoBehaviour
{

    public int footon;

    private GameObject obGamerule;
    private Gamerule Gamerule;

    // Start is called before the first frame update
    void Start()
    {
        obGamerule = GameObject.Find("GameRule");
        Gamerule = obGamerule.GetComponent<Gamerule>();
    }

    void OnTriggerStay(Collider col)
    {
        footon = Gamerule.Touch(col);
    }

    void OnTriggerExit(Collider col)
    {
        footon = 0;
    }
}
