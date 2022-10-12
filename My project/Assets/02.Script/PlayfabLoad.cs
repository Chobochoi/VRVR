using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;


public class PlayerfabLoad : MonoBehaviour
{
    public void Login()
    {
        var request = new LoginWithEmailAddressRequest { Email = "abc@naver.com", Password = "123123" };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    }
    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }

    public class DataContent
    {

        public int objectLength;
        public string userID;

        public string storeName;
        public int storeNum;

        public string objectName;

        public int prefabTypeNum;
        public float objectScale;
        public float objectPositionX;
        public float objectPositionY;
        public float objectPositionZ;
        public float objectRotateX;
        public float objectRotateY;
        public float objectRotateZ;
        public float objectRotateSpeed;
    }


    public void LoadUserData(string ManagerEmail)
    {
        var request = new GetUserDataRequest() { PlayFabId = ManagerEmail };

        PlayFabClientAPI.GetUserData(request, (result) =>
        {
            foreach (var eachData in result.Data)
            {
                string key = eachData.Key;
                if (eachData.Key.Contains("Object"))
                {
                    DataContent dataContent = JsonUtility.FromJson<DataContent>(eachData.Value.Value);
                    Debug.Log(dataContent.objectName);
                    MakeInstance(dataContent);
                }
            }

        },
        Debug.Log);
    }

    public void MakeInstance(DataContent data)
    {
        string selectType = data.prefabTypeNum.ToString();
        string objectname = data.objectName;
        int storeNum = data.storeNum;
        string storeName = data.storeName;
        int objectLength = data.objectLength;
        string userID = data.userID;

        float objectPositionX = data.objectPositionX;
        float objectPositionY = data.objectPositionY;
        float objectPositionZ = data.objectPositionZ;
        float objectRotateX = data.objectRotateX;
        float objectRotateY = data.objectRotateY;
        float objectRotateZ = data.objectRotateZ;
        float objectScale = data.objectScale;
        float objectRotateSpeed = data.objectRotateSpeed;

        Vector3 instancePos = new Vector3(objectPositionX, objectPositionY, objectPositionZ);
        Quaternion objrotation = new Quaternion();
        objrotation.x = objectRotateX;
        objrotation.y = objectRotateY;
        objrotation.y = objectRotateZ;


        GameObject obj = Resources.Load(selectType) as GameObject;

        GameObject instance = Instantiate(obj, instancePos, objrotation);
        instance.name = objectname;
        instance.transform.localScale = new Vector3(objectScale, objectScale, objectScale);
    }


}
