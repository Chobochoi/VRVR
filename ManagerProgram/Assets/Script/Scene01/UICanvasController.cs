using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class UICanvasController : MonoBehaviour
{
    GameObject obj;
    public GameObject Store001;
    public GameObject Store002;
    public GameObject Store003;
    public GameObject Store004;

    bool S001 = false;
    bool S002 = false;
    bool S003 = false;
    bool S004 = false;

    public Canvas canvas;
    public InputField storenameInput;
    public TextMeshProUGUI storename;

    public void ChangeObject(int SetObject)
    {

        if(SetObject == 1 && S001 )
        {return;}
        if(SetObject == 2 && S002 )
        {return;}
        if(SetObject == 3 && S003 )
        {return;}
        if(SetObject == 4 && S004 )
        {return;}
        
        if(SetObject == 1 && !S001 )
        {
            GameManager.instance.storeNum = 1;
            Store002.gameObject.SetActive(false);
            Store003.gameObject.SetActive(false);
            Store004.gameObject.SetActive(false);
            
            Store001.gameObject.SetActive(true);
        }
        else if(SetObject == 2 && !S002)
        {
            GameManager.instance.storeNum = 2;
            Store001.gameObject.SetActive(false);
            Store003.gameObject.SetActive(false);
            Store004.gameObject.SetActive(false);
            
            Store002.gameObject.SetActive(true);
        }
        else if(SetObject == 3 && !S003)
        {
            GameManager.instance.storeNum = 3;
            Store001.gameObject.SetActive(false);
            Store002.gameObject.SetActive(false);
            Store004.gameObject.SetActive(false);
            
            Store003.gameObject.SetActive(true);
        }
        else if(SetObject == 4 && !S004)
        {
            GameManager.instance.storeNum = 4;
            Store001.gameObject.SetActive(false);
            Store002.gameObject.SetActive(false);
            Store003.gameObject.SetActive(false);
            
            Store004.gameObject.SetActive(true);
        }

    }

    public void SaveBTN()
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

    public void ResetBTN()
    {
        SceneManager.LoadScene(1);
    }



    public void StoreNameBTN(Text storeName)
    {
        storeName.text = storenameInput.text;
        GameManager.instance.storeName = storeName.text;
        storename.text = GameManager.instance.storeName;
        GameManager.instance.storeNameSecondChange = true;
        canvas.gameObject.SetActive(false);

    }
    public void StoreNameExitBTN()
    {
        storenameInput.text = "";
        if(GameManager.instance.storeNameSecondChange == true)
        {
            canvas.gameObject.SetActive(false);
        }
    }

}
