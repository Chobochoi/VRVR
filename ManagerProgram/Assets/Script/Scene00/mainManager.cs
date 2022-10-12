using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class mainManager : MonoBehaviour
{
    public InputField userID;
    public InputField passWord;

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
        GameManager.instance.playfabId = result.PlayFabId;
        SceneManager.LoadScene(1);
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }
    public void LoginBTN()
    {
        GameManager.instance.userID = userID.text;
        GameManager.instance.passWord = passWord.text;
        Login();
    }

    public void Login()
    {
        var request = new LoginWithEmailAddressRequest { Email = GameManager.instance.userID, Password = GameManager.instance.passWord };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
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
