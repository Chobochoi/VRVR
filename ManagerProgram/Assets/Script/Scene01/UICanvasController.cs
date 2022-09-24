using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

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
            Store002.gameObject.SetActive(false);
            Store003.gameObject.SetActive(false);
            Store004.gameObject.SetActive(false);
            
            Store001.gameObject.SetActive(true);
        }
        else if(SetObject == 2 && !S002)
        {
            Store001.gameObject.SetActive(false);
            Store003.gameObject.SetActive(false);
            Store004.gameObject.SetActive(false);
            
            Store002.gameObject.SetActive(true);
        }
        else if(SetObject == 3 && !S003)
        {
            Store001.gameObject.SetActive(false);
            Store002.gameObject.SetActive(false);
            Store004.gameObject.SetActive(false);
            
            Store003.gameObject.SetActive(true);
        }
        else if(SetObject == 4 && !S004)
        {
            Store001.gameObject.SetActive(false);
            Store002.gameObject.SetActive(false);
            Store003.gameObject.SetActive(false);
            
            Store004.gameObject.SetActive(true);
        }

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
        SceneManager.LoadScene(2);
    }

}
