using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Canvas canvas;
    public Canvas menuCanvas;
    public bool UIONOFF = false;
    public bool UserModCheck = true;
    public Camera userModCamera;
    public Camera managerModCamera;
    public GameObject userRoom;
    public GameObject managerRoom;

    void Awake()
    {
        userModCamera.enabled = true;
        managerModCamera.enabled =false;
    }
    void Update()
    {
        OpenMenuUI();
    }

    public void SaveBTN()
    {
    }

    public void ResetBTN()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitBTN()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void BackBTN()
    {
        SceneManager.LoadScene(1);
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
        userRoom.SetActive(true);
        managerRoom.SetActive(false);
        
        userModCamera.enabled = true;
        managerModCamera.enabled =false;
    }
    public void ManagerMod()
    {
        if(UIONOFF == true)
        {
            return;
        }
        
        UserModCheck = false;
        canvas.gameObject.SetActive(true);
        userRoom.SetActive(false);
        managerRoom.SetActive(true);
        
        userModCamera.enabled = false;
        managerModCamera.enabled = true;
    }
}
