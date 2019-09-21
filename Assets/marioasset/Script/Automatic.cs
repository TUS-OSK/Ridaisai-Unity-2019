using UnityEngine;
using System.Collections;
public class Automatic : MonoBehaviour
{
    public GameObject ground2;
    public GameObject ground3;
    public GameObject num1;
    public GameObject fallblock;
    int border = 1000;
    void Update()
    {
        if (transform.position.z > border)
        {
          //  CreateMap();
        }
    }
    //void CreateMap()
    //{
    //    if (green1.transform.position.z < border)
    //    {
    //        border += 2000;
    //        Vector3 temp = new Vector3(0, 0.05f, border);
    //        green1.transform.position = temp;
    //    }
    //    else if (green2.transform.position.z < border)
    //    {
    //        border += 2000;
    //        Vector3 temp = new Vector3(0, 0.05f, border);
    //        green2.transform.position = temp;
    //    }
    //}
}