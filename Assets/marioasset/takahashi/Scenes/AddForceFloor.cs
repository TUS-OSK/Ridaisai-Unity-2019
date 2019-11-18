﻿using System.Collections;
using UnityEngine;

public class AddForceFloor : MonoBehaviour
{
    // Start is called before the first f  ,5rame update

    //落下したあと復活するように追記
    private void Update()
    {
        if (transform.position.y < -10)
        {
            //transform.position = Vector3.right * transform.position.x + Vector3.up * 4 + Vector3.forward * transform.position.z;
            transform.position = new Vector3(transform.position.x, 0, 0);

            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Invoke("Fall",2);
    }
    private void Fall()
    {
        //蹴った衝撃で沈まないようにkineticの処理を
        GetComponent<Rigidbody>().isKinematic = false;

        GetComponent<Rigidbody>().useGravity = true;
    }
}
