using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainManager : MonoBehaviour
{
    public InputField userID;

    public void LoginBTN()
    {
        GameManager.instance.userID = userID.text;
        SceneManager.LoadScene(1);
    }

    public void ExitBTN()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
