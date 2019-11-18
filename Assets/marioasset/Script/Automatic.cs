using UnityEngine;
using System.Collections;
public class Automatic : MonoBehaviour
{
    public GameObject ground2;
    public GameObject ground3;
    public GameObject num1;
    public GameObject fallblock;
    public GameObject kanransha;
    public GameObject pentagon;
    private GameObject[] StageArray = null;
    
    float border = 0.9635f;
    //float border2 = 2.2f;
    //float border3 = 8.01f;
    //float border4 = 8.27f;
    [SerializeField]
    private GameObject now;
    int number;
    private void Start()
    {
        now = num1;
        StageArray = new GameObject[]
        {
            num1,ground2,ground3,fallblock,kanransha,pentagon
        };
    }
    void Update()
    {
        if (transform.position.x > border)
        {
            CreateMap();
        }
        //if (transform.position.x < border2)
        //{
        //    if (transform.position.y < -1.5f)
        //    {
        //        Vector3 save = new Vector3(border2 - 2.381f, 0.7f, 0);
        //        transform.position = save;
        //    }
        //}
        //if (transform.position.x > border2)
        //{
        //    border2 += 2.675f;
        //}
    }
        void CreateMap()
    {
        if (Mathf.Abs(now.transform.position.x - border) < 0.01f)
        {
            number = Random.Range(0, StageArray.Length);
            var next = Instantiate(StageArray[number]);
            border += 2.675f;
            Vector3 temp = new Vector3(border, 0, 0);
            next.transform.position = temp;
            now = next;
        }
        //if (Mathf.Abs(ground2.transform.position.x - border2) < 0.01f)
        //{
        //    var next = Instantiate(ground2);
        //    border2 += 9.5f;
        //    Vector3 temp = new Vector3(border2, 0, 0);
        //    next.transform.position = temp;
        //    ground2 = next;

        //}
        //if (Mathf.Abs(ground3.transform.position.x - border3) < 0.01f)
        //{
        //    var next = Instantiate(ground3);
        //    border3 += 9.5f;
        //    Vector3 temp = new Vector3(border3, 0, 0);
        //    next.transform.position = temp;
        //    ground3 = next;

        //}
        //if (Mathf.Abs(fallblock.transform.position.x - border4) < 0.01f)
        //{
        //    var next = Instantiate(fallblock);
        //    border4 += 9.5f;
        //    Vector3 temp = new Vector3(border4, 0, 0);
        //    next.transform.position = temp;
        //    fallblock = next;

        //}
    }
}