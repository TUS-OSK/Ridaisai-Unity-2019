using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody rigid;
    bool dire = true;
    float power = 30.0f;
    float maxspeed = 1.0f;
    void Start()
    {
        this.rigid = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float nowspeed = Mathf.Abs(this.rigid.velocity.x);
        if (nowspeed == 0) { if (dire) { dire = false; } else { dire = true; } }
        if (nowspeed < maxspeed)
        {

            if (dire)
            {
                this.rigid.AddForce(transform.forward * power * -1);
            }
            else
            {
                this.rigid.AddForce(transform.forward * power);
            }
            void OnCollisionEnter(Collision col)
            {
                if (col.gameObject.CompareTag("Wall"))
                { if (dire) { dire = false; } else { dire = true; } }
            }

        }
    }
}