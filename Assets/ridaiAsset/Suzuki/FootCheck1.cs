using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootCheck1 : MonoBehaviour
{

    PlayerStatus playerStatus;

    private void Start()
    {
        playerStatus = gameObject.transform.parent.gameObject.GetComponent<Player1>().playerStatus;
    }

    void OnTriggerEnter()
    {
        playerStatus.footOn = true;
        GameObject.Find("GameRule").GetComponent<ContactDeal>().Touch(playerStatus, true);
    }

    void OnTriggerExit()
    {
        playerStatus.footOn = false;

    }

}
