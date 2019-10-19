using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : MonoBehaviour
{
    Rigidbody rigid;
    private float _revers = 1;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move(_revers);
    }

    private void Move(float revers)
    {
        transform.position += new Vector3(-0.1f * revers, 0f, 0f);
    }

    private void OnTriggerEnter(Collider col)
    {
        _revers *= -1;
        Vector3 vector3 = gameObject.transform.localScale;
        if (col.gameObject.tag == "wall")
        {
            Debug.Log("壁に当たる");
            this.transform.eulerAngles += Vector3.down * 180f;
            vector3.x *= -1;
        }
        transform.localScale = vector3;
    }
}
