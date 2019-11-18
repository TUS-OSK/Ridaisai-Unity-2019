using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorchange : MonoBehaviour
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
    private bool IsOpend;
    private BoxCollider box;
    private SphereCollider sphere;
    private BoxCollider playerCollider;
    private Material[] colors=null;
    private GameObject[] pentagons = null;
    int number,number2;

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

        box = GetComponent<BoxCollider>();
        sphere = GetComponentInChildren<SphereCollider>();
        IsOpend = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (ContactPoint c in collision.contacts)
            {
                if (c.thisCollider.name == "Undertrigger")
                {
                    IsOpend = true;
                    if (IsOpend == true)
                    {
                        number = Random.Range(0, colors.Length);
                        number2 = Random.Range(0, pentagons.Length);
                        pentagons[number2].GetComponent<Renderer>().material.color = colors[number].color;
                    }
                }
            }
        }
    }
}
