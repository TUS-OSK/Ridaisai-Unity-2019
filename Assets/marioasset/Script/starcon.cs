using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starcon : MonoBehaviour
{
    private BoxCollider star;
    private Rigidbody rd;
    private Transform myTransform;
    private float _reverse = -1;
    // Start is called before the first frame update
    void Start()
    {
        star = GetComponent<BoxCollider>();
        rd = GetComponent<Rigidbody>();
       //myTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        myTransform = this.transform;

        Vector3 pos = myTransform.position;
        pos.x += -0.001f;
        myTransform.position = pos;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Vector3 pos = myTransform.position;
        //pos.x += -0.05f;
        //myTransform.position = pos;
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
