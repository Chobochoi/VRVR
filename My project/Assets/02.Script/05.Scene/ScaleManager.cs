using UnityEngine;

public class ScaleManager : MonoBehaviour
{    
    float rayDistance = 30f;
    public GameObject CatWheel;
    bool OnAnim = false;
    public Animator anim;

    public void Start()
    {
        CatWheel = GameObject.Find("CatWheelforUnity");

        
        if (anim != null)
            Debug.Log("123");

        else if (anim == null)
            Debug.Log(anim);
    }


    void Update()
    {
        ObjHit();
    }
    

    public void ObjHit()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.A))        
        {
            Ray ray = new Ray(transform.position, transform.forward * rayDistance);
            RaycastHit hitData;
            Debug.Log(anim.GetBool("OnAnimation"));
         Debug.DrawRay(transform.position, transform.forward, Color.blue, rayDistance);

            if (Physics.Raycast(transform.position, transform.forward, out hitData, Mathf.Infinity, LayerMask.GetMask("Object")) && !OnAnim)
            {   
                OnAnim = true;
                anim.SetBool("OnAnimation", true);
                Debug.Log("if");
                //temp = hitData.collider.gameObject;
                //hitData.transform.localScale = new Vector3(MaxScale, MaxScale, MaxScale);
                
            }


            else
            {
                OnAnim = false;
                anim.SetBool("OnAnimation", false);
            }

            /*else
            {
                if (temp != null)
               {
                    temp.transform.localScale = new Vector3(MinScale, MinScale, MinScale);
                    temp = null;
                }
            }*/
        }
    }


}
