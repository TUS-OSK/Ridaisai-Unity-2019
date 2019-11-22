using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iconcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Vector3 pos = myTransform.position;
        //pos.x += -0.05f;
        //myTransform.position = pos;
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}

