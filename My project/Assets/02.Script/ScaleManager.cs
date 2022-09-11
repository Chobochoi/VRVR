using UnityEngine;
 

public class ScaleManager : MonoBehaviour
{
    [SerializeField] float MaxScale = 2f;
    [SerializeField] float MinScale = 0.5f;
    float rayDistance = 30f;
    
    void Update()
    {
        ObjHit();
    }
    GameObject temp;

    public void ObjHit()
    {
        Ray ray = new Ray(transform.position, transform.forward * rayDistance);
        RaycastHit hitData;

        if(OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RHand))        
        {
            if (Physics.Raycast(transform.position, transform.forward, out hitData, Mathf.Infinity, LayerMask.GetMask("Object")))
            {
                temp = hitData.collider.gameObject;
                hitData.transform.localScale = new Vector3(MaxScale, MaxScale, MaxScale);
            }
            else
            {
                if (temp != null)
                {
                    temp.transform.localScale = new Vector3(MinScale, MinScale, MinScale);
                    temp = null;
                }
            }
        }     
    }
}

