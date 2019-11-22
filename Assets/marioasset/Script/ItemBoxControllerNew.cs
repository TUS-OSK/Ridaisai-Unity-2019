using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxControllerNew : MonoBehaviour
{
    public GameObject content;
    private Vector2 movepoint;
    private bool IsOpend;
    private bool IsActive;

    private SpriteRenderer sr;
    private BoxCollider box;
    private SphereCollider sphere;
    private BoxCollider playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerCollider = player.GetComponent<BoxCollider>();
        }

        sr = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider>();
        sphere = GetComponentInChildren<SphereCollider>();

        content = Instantiate(content);
        content.transform.position = transform.position;
        content.transform.SetParent(gameObject.transform);
        content.gameObject.SetActive(false);

        IsOpend = false;
        IsActive = true;

        movepoint = (Vector2)transform.position + new Vector2(0.0f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOpend == true && IsActive == true)
        {
            content.transform.position = Vector2.Lerp(content.transform.position, movepoint, 0.35f);
            sr.color = Color.Lerp(sr.color, Color.grey, 0.4f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("あたった");
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach(ContactPoint c in collision.contacts)
            {
                if(c.thisCollider.name == "Undertrigger")
                {
                    StartCoroutine(DelayMethod(0.5f, () => {
                        content.gameObject.SetActive(true);
                        IsOpend = true;    
                    }));
                    
                    StartCoroutine(WaitSwitchOff());
                    //Debug.Log("ok");
                    Destroy(transform.GetChild(0).gameObject);
                    Destroy(transform.GetChild(1).gameObject);
                    break;
                }
                if(c.thisCollider.name == "Icons_4(Clone)")
                {
                        Destroy(transform.GetChild(0).gameObject);
                }
            }
        }
    }

    private IEnumerator WaitSwitchOff()
    {
        yield return new WaitForSeconds(1.0f);
        IsActive = false;
    }

    private IEnumerator DelayMethod(float delayTime, System.Action action){
        yield return new WaitForSeconds(delayTime);
        action();
    }
}
//GameObject.Find("Icons_4(Clone)").transform.IsChildOf(transform)
