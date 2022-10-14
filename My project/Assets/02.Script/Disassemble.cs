using System.Collections.Generic;
using UnityEngine;

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

        foreach (Transform item in transform)
        {
            childlist.Add(item);

            foreach (Transform obj in item)
            {
                childlist.Add(obj);
            }
        }

        for (int i = 0; i < childlist.Count; i++)
        {
            childPoslist.Add(childlist[i].transform.position + new Vector3(-offset * i, 0, 0));
        }


    }

    void Update()
    {
        for (int i = 0; i < childlist.Count; i++)
        {
            childlist[i].position = Vector3.MoveTowards(childlist[i].position, childPoslist[i], Time.deltaTime * 5);
        }

        //Vector3.MoveTowards()
    }
}
