using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public float speed = 30f;

    public int value;

    void Update()
    {
        RotateObject();
    }

    void RotateObject()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
