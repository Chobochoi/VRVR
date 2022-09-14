using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button1 : MonoBehaviour
{
    [SerializeField] public Button btn1;
    
    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            gameObject.SetActive(true);
        }
    }
}
