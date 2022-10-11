using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [HideInInspector]public Canvas canvas;
    [HideInInspector]public Canvas menuCanvas;
    public Canvas changeCanves;
    public Canvas ModCanvas;
    [HideInInspector] public bool UIONOFF = false;
    [HideInInspector] public bool UserModCheck = true;
    [HideInInspector] public bool ChangeModCheck = false;

    [HideInInspector] public Camera userModCamera;
    [HideInInspector] public Camera managerModCamera;
    [HideInInspector] public GameObject userRoom;
    [HideInInspector] public GameObject managerRoom;
    [HideInInspector] public Button deleteBTN;
    [HideInInspector] public ManagerObject managerObject;
    [HideInInspector] public int selectNum = 0;


    void Awake()
    {
        userModCamera.enabled = true;
        managerModCamera.enabled =false;
    }
    void Update()
    {
        OpenMenuUI();
        SelectDeleteBTN();
    }

    public void SaveBTN()
    {

        GameManager.instance.SaveJsonToPlayfab();
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
        menuCanvas.gameObject.SetActive(false);
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

    void SelectDeleteBTN()
    {
        if (GameManager.instance.selectObjectNumber == 0)
        {
            ColorBlock colorBlock = deleteBTN.colors;
            colorBlock.normalColor = Color.red;
            deleteBTN.colors = colorBlock;
        }
        else if(GameManager.instance.selectObjectNumber != 0)
        {
            ColorBlock colorBlock = deleteBTN.colors;
            colorBlock.normalColor = Color.white;
            deleteBTN.colors = colorBlock;

        }
    }

    public void SelectObject(int number)
    {
        selectNum = number;
        GameManager.instance.selectObjectNumber = selectNum;
    }

    public void ChangeBTN()
    {
        if (ChangeModCheck == true)
        {
            return;
        }

        ChangeModCheck = true;
        ModCanvas.gameObject.SetActive(false);
        canvas.gameObject.SetActive(false);
        changeCanves.gameObject.SetActive(true);
        managerObject.ChangeObject();
    }

    public void BackChangeBTN()
    {
        ChangeModCheck = false;
        ModCanvas.gameObject.SetActive(true);
        canvas.gameObject.SetActive(true);
        changeCanves.gameObject.SetActive(false);
        managerObject.ChangeObject();
    }

}
