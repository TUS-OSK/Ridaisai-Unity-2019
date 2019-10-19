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
        Vector3 vector3 = gameObject.transform.localScale;
        if (col.gameObject.tag == "wall"||col.gameObject.tag == "Nokonoko")
        {
            Debug.Log("壁に当たる");
            _revers *= -1;
            this.transform.eulerAngles += Vector3.down * 180f;
            vector3.x *= -1;
        }
        transform.localScale = vector3;
    }

    public void EnemyDeath()
    {
        Destroy(this.gameObject);
    }
}
