using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorchangekari : MonoBehaviour
{
    public GameObject penta1;
    public GameObject penta2;
    public Material colorA;
    public Material colorB;
    public Material colorC;
    public Material colorD;
    public Material colorE;
    public Material colorF;
    public Material colorG;
    public Material colorH;
    public Material colorI;
    public Material colorJ;
    //public GameObject content;
    //private Vector2 movepoint;
    private bool IsOpend;
    //private bool IsActive;

    private SpriteRenderer sr1, sr2;
    //private BoxCollider[] m_colliders;
    private BoxCollider box;
    private SphereCollider sphere;
    private BoxCollider playerCollider;
    private Material[] colors = null;
    private GameObject[] pentagons = null;
    int number, number2;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerCollider = player.GetComponent<BoxCollider>();
        }

        colors = new Material[]
        {
            colorA,colorB,colorC,colorD,colorE,colorF,colorG,colorH,colorI,colorJ
        };
        pentagons = new GameObject[]
        {
            penta1,penta2
        };
        /*penta1.GetComponent<Renderer>().material.color = colorA.color;*/

        // m_colliders = GetComponentsInChildren<BoxCollider>();
        box = GetComponent<BoxCollider>();
        sphere = GetComponentInChildren<SphereCollider>();

        // content = Instantiate(content);
        //content.transform.position = transform.position;
        // content.transform.SetParent(gameObject.transform);
        //content.gameObject.SetActive(false);

        IsOpend = false;
        //IsActive = true;

        //movepoint = (Vector2)transform.position + new Vector2(0.0f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        //if (IsOpend == true && IsActive == true)
        //{
        //    // content.transform.position = Vector2.Lerp(content.transform.position, movepoint, 0.35f);
        //    // sr1.color = Color.Lerp(sr1.color, Color.grey, 0.4f);
        //    // sr2.color = Color.Lerp(sr2.color, Color.grey, 0.4f);
        //    number = Random.Range(0, colors.Length);
        //    penta1.GetComponent<Renderer>().material.color = colors[number].color;
        //}

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (ContactPoint c in collision.contacts)
            {
                if (c.thisCollider.name == "Undertrigger")
                {

                    //content.gameObject.SetActive(true);
                    IsOpend = true;
                    //StartCoroutine(WaitSwitchOff());
                   // Debug.Log("ok");
                    // Destroy(transform.GetChild(0).gameObject);
                    //break;
                    if (IsOpend == true /*&& IsActive == true*/)
                    {
                        // content.transform.position = Vector2.Lerp(content.transform.position, movepoint, 0.35f);
                        // sr1.color = Color.Lerp(sr1.color, Color.grey, 0.4f);
                        // sr2.color = Color.Lerp(sr2.color, Color.grey, 0.4f);
                        number = Random.Range(0, colors.Length);
                        number2 = Random.Range(0, pentagons.Length);
                        pentagons[number2].GetComponent<Renderer>().material.color = colors[number].color;
                    }
                }
            }
        }
    }

    /* private IEnumerator WaitSwitchOff()
      {
          yield return new WaitForSeconds(5.0f);
         //IsActive = false;
      }*/

}
