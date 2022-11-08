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
<<<<<<< HEAD
    public InputActionReference rightHandSelect;
    public GameObject Product;
    float rayDistance = 30.0f;    

    //[Range(0.05f, 0.1f)] '바'로 조절 (어트리뷰트)

    private void Awake()
    {
        rightHandSelect.action.started += OnRightHandSelect;
    }

    void Start()
    {
        Product = GameObject.Find("Watch");

=======
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

>>>>>>> parent of 83e44b23 (Oct24)
        for (int i = 0; i < childlist.Count; i++)
        {
            childPoslist.Add(childlist[i].transform.position + new Vector3(-offset * i, 0, 0));
        }
    }

    void Update()
    {
        RayClick();
        //Disassam();        
    }

<<<<<<< HEAD
    //public void Disassam()
    //{
    //    foreach (Transform item in transform)
    //    {
    //        childlist.Add(item);

    //        foreach (Transform obj in item)
    //        {
    //            childlist.Add(obj);
    //        }
    //    }       
    //}

    public void RayClick()
    {
        Ray ray = new Ray(transform.position, transform.forward * rayDistance);
        RaycastHit hitData;

        if (Physics.Raycast(transform.position, transform.forward, out hitData, Mathf.Infinity, LayerMask.GetMask("Object")))
        {
            for (int i = 0; i < childlist.Count; i++)
            {
                childlist[i].position = Vector3.MoveTowards(childlist[i].position, childPoslist[i], Time.deltaTime * 5);
            }
        }              
    }

    public void OnRightHandSelect(InputAction.CallbackContext context)
    {
        RayClick();
=======
    }

    void Update()
    {
        for (int i = 0; i < childlist.Count; i++)
        {
            childlist[i].position = Vector3.MoveTowards(childlist[i].position, childPoslist[i], Time.deltaTime * 5);
        }

        //Vector3.MoveTowards()
>>>>>>> parent of 83e44b23 (Oct24)
    }
}
