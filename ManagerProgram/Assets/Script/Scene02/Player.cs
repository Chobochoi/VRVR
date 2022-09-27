using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float mvSpeed = 10.0f;
    public float roSpeed = 150.0f;

    Vector3 mvVec;
    Vector3 roVec;
    public UIController UI;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        if(UI.UIONOFF == false && UI.UserModCheck == true)
        {        
            if(Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0 )
            {
                transform.Translate(0,0,0);
                transform.Rotate(0,0,0);
            }

            else
            {
            float mv = Input.GetAxis("Vertical") * mvSpeed * Time.deltaTime;
            float ro = Input.GetAxis("Horizontal") * roSpeed * Time.deltaTime;
        
            transform.Translate(0,0,mv);
            transform.Rotate(0,ro,0);
            }
        }




    }

}
