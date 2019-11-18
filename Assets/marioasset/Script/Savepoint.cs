using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Savepoint : MonoBehaviour
{
    float border2 = 2.4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < border2)
        {
            if (transform.position.y < -12f)
            {
                Vector3 save = new Vector3(border2 - 2.381f, 5f, 0);
                transform.position = save;
            }
        }
        if (transform.position.x > border2)
        {
            border2 += 2.675f;
        }
    }
}
