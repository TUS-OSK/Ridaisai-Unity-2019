using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starcontroller : MonoBehaviour
{
    private BoxCollider star;
    private Rigidbody rd;
    private float _reverse = -1;
    // Start is called before the first frame update
    void Start()
    {
        star = GetComponent<BoxCollider>();
        rd = GetComponent<Rigidbody>();
        Fall(_reverse);
    }

    // Update is called once per frame
    void Update()
    {
        Fall(_reverse);
    }

    private void Fall(float reverse)
    {
        transform.position += new Vector3(0.01f, 0.1f * reverse, 0f);
    }
    private void OnTriggerEnter(Collider col)
    {
        //Vector3 vector3 = gameObject.transform.localScale;
        if (col.gameObject.tag == "Star")
        {
            Debug.Log("ok");
            _reverse*= -1;
            //this.transform.eulerAngles += Vector3.down * 180f;
          // vector3.x *= -1;
        }
       //transform.localScale = vector3;
    }







    //private void OnCollisionEnter(Collision collision)
    //{
    //if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Destroy(gameObject);
    //    }
    //    else
    //    {
    //        _reverse *= -1;
    //        Fall(_reverse);
    //        Debug.Log("ok");
    //    }
    //}



}
