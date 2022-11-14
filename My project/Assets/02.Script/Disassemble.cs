using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class Disassemble : MonoBehaviour
{
    [SerializeField]
    List<Transform> childlist;
    [SerializeField]
    List<Vector3> childPoslist;
    [SerializeField]
    float offset;
    //public InputActionReference rightHandSelect;
    //public GameObject Product;
    //float rayDistance = 30.0f;

    [SerializeField]
    XRSimpleInteractable interact;

    private Vector3 originalPos;

    //[Range(0.05f, 0.1f)] '바'로 조절 (어트리뷰트)

    private void Awake()
    {
        //rightHandSelect.action.started += OnRightHandSelect;
    }

    void Start()
    {
        //Product = GameObject.Find("Watch");

        for (int i = 0; i < childlist.Count; i++)
        {
            childPoslist.Add(childlist[i].transform.position + new Vector3(0, 0, -offset * i));
        }

        originalPos = transform.position;

        interact.hoverEntered.AddListener(WatchEnter);
        interact.hoverExited.AddListener(WatchExit);
        interact.selectEntered.AddListener(RayClick);
    }

    void Update()
    {
        //RayClick();
        //Disassam();

    }

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

    public void RayClick(SelectEnterEventArgs arg)
    {
        //Ray ray = new Ray(transform.position, transform.forward * rayDistance);
        //RaycastHit hitData;

        //if (Physics.Raycast(transform.position, transform.forward, out hitData, Mathf.Infinity, LayerMask.GetMask("Object")))
        //{
        for (int i = 0; i < childlist.Count; i++)
        {
            childlist[i].position = Vector3.MoveTowards(childlist[i].position, childPoslist[i], Time.deltaTime * 5);
        }
        //}              
    }

    public void OnRightHandSelect(InputAction.CallbackContext context)
    {
        //RayClick();
    }

    private void WatchEnter(HoverEnterEventArgs arg)
    {
        Vector3 dir = Camera.main.transform.position - transform.position;
        transform.position += dir.normalized * 1.3f;
    }

    private void WatchExit(HoverExitEventArgs arg)
    {
        transform.position = originalPos;
    }
}