using System.Collections;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public float baseTime;
    private float time;
    private void OnCollisionEnter(Collision collision)
    {
        Invoke("Fall", 0.5f);
    }
    private void Fall()
    {
        GetComponent<Rigidbody>().useGravity = true;
        StartCoroutine(Stop());
    }

    private IEnumerator Stop()
    {
        while (true)
        {
            time += Time.deltaTime;
            if (baseTime < time)
            {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                time = 0;
            }
            yield return null;
        }
    }
}
