using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public float speed = 30f;

    public int value;
    Vector3 ObjPos;


    void Update()
    {
        RotateObject();
    }

    void RotateObject()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Object")
        {
            ObjectController OC = other.gameObject.GetComponent<ObjectController>();
            ObjectController MYOC = gameObject.GetComponent<ObjectController>();

            if(MYOC.value > OC.value)
            {
                Destroy(gameObject);
            }
        }
    }
}
