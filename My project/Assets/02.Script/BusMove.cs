using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusMove : MonoBehaviour
{

    [SerializeField]
    Transform parent;
    [SerializeField]
    List<Vector3> waypoints;
    float speed = 0.1f;


    void Start()
    {
        foreach (Transform item in parent)
        {
            waypoints.Add(item.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[0], Time.deltaTime * speed);

        //if (Vector3.Distance(transform.position, waypoints[0]) <= 0)

    }
}
