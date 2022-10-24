using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Disassemble : MonoBehaviour
{
    [SerializeField]
    List<Transform> childlist;
    [SerializeField]
    List<Vector3> childPoslist;
    [SerializeField]
    float offset;
    //[Range(0.05f, 0.1f)] '바'로 조절 (어트리뷰트)    

    void Start()
    {      

    }

    void Update()
    {
        Disassam();        
    }

    public void Disassam()
    {
        foreach (Transform item in transform)
        {
            childlist.Add(item);

            foreach (Transform obj in item)
            {
                childlist.Add(obj);
            }
        }       
    }

    public void RayClick()
    {
        for (int i = 0; i < childlist.Count; i++)
        {
            childPoslist.Add(childlist[i].transform.position + new Vector3(0, 0, -offset * i));
        }


        for (int i = 0; i < childlist.Count; i++)
        {
            childlist[i].position = Vector3.MoveTowards(childlist[i].position, childPoslist[i], Time.deltaTime * 5);
        }
    }
}
