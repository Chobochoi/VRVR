using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleManager : MonoBehaviour
{
    [SerializeField] float MaxScale = 2f;
    [SerializeField] float MinScale = 0.5f;
    float rayDistance = 30f;
    private void Start()
    {
    }

    void Update()
    {
        ObjHit();
    }
    GameObject temp;
    
    public void ObjHit()
    {
        Ray ray = new Ray(transform.position, transform.forward * rayDistance);
        RaycastHit hitData;
               
        if (Physics.Raycast(transform.position, transform.forward, out hitData, Mathf.Infinity, LayerMask.GetMask("Object")))
            {
                hitData.transform.localScale *= 2;
                LayerMask.GetMask("Object");
                hitData.transform.localScale = new Vector3(MaxScale, MaxScale, MaxScale);
                temp = hitData.collider.gameObject;
            }
        else
            {
                if (temp != null)
                hitData.transform.localScale *= 0.5f;
            hitData.transform.localScale = new Vector3(MinScale, MinScale, MinScale);
        }
        
        
    
    }
}
