using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Canvas canvas;
    public Canvas menuCanvas;
    public bool UIONOFF = false;
    public bool UserModCheck = true;
    void Update()
    {
        OpenMenuUI();
    }


    public void OpenMenuUI()
    {
        if(Input.GetKeyDown("escape"))
        {
            if(UserModCheck == true)
            {
                if(UIONOFF == false)
                {
                    menuCanvas.gameObject.SetActive(true);
                    canvas.gameObject.SetActive(false);
                    UIONOFF =true;
                }
                else
                {
                    menuCanvas.gameObject.SetActive(false);
                    UIONOFF = false;
                }
            }
            else if(UserModCheck == false)
            {
                if(UIONOFF == false)
                {
                    menuCanvas.gameObject.SetActive(true);
                    canvas.gameObject.SetActive(false);
                    UIONOFF =true;
                }
                else
                {
                    menuCanvas.gameObject.SetActive(false);
                    canvas.gameObject.SetActive(true);
                    UIONOFF = false;
                }
            }
        }
    }

    public void UserMod()
    {
        if(UIONOFF == true)
        {
            return;
        }
        UserModCheck = true;
        canvas.gameObject.SetActive(false);
    }
    public void ManagerMod()
    {
        if(UIONOFF == true)
        {
            return;
        }
        UserModCheck = false;
        canvas.gameObject.SetActive(true);
    }
}
