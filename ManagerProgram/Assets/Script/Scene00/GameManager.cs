using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        
        DontDestroyOnLoad(gameObject);
    }
    public string playfabId;



    public bool storeNameSecondChange = false;
    public int selectObjectNumber = -1;
    public GameObject selectedObj;

    public string userID;
    public string passWord;
    public string storeName;
    public int storeNum;

    public string objectName;
    public int objectLength;

    public int prefabTypeNum;
    public float objectScale;
    public float objectPositionX;
    public float objectPositionY;
    public float objectPositionZ;
    public float objectRotateX;
    public float objectRotateY;
    public float objectRotateZ;
    public float objectRotateSpeed;


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




    public void ResetUserData()
    {
        var request = new GetUserDataRequest() { PlayFabId = playfabId};

        PlayFabClientAPI.GetUserData(request, (result) =>
        {
            GameObject[] obj = GameObject.FindGameObjectsWithTag("Object");
            GameManager.instance.objectLength = obj.Length;

            List<string> deleteKeys = new List<string>();
            if(result.Data.Count > obj.Length)
            {
                for(int i = obj.Length; i<result.Data.Count; i++)
                {
                    deleteKeys.Add("Object" + i);
                }
                DeleteUserData(deleteKeys);
            }
            SaveJsonToPlayfab();
        },Debug.Log);

    }




    public void SaveJsonToPlayfab()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Object");

        GameManager.instance.objectLength = obj.Length;

        DataContent content = new DataContent();
        for (int i = 0; i < obj.Length; i++)
        {
            ObjectController OC = obj[i].GetComponent<ObjectController>();

            content.objectLength = GameManager.instance.objectLength;
            content.userID = GameManager.instance.userID;
            content.storeName = GameManager.instance.storeName;
            content.storeNum = GameManager.instance.storeNum;
            content.objectName = "Object" + i;

            content.prefabTypeNum = OC.prefabTypeNum;
            content.objectScale = obj[i].transform.localScale.x;
            content.objectPositionX = obj[i].transform.position.x;
            content.objectPositionY = obj[i].transform.position.y;
            content.objectPositionZ = obj[i].transform.position.z;
            content.objectRotateX = obj[i].transform.localEulerAngles.x;
            content.objectRotateY = obj[i].transform.localEulerAngles.y;
            content.objectRotateZ = obj[i].transform.localEulerAngles.z;
            content.objectRotateSpeed = OC.speed;

            Dictionary<string, string> dataDic = new Dictionary<string, string>();
            dataDic.Add(content.objectName, JsonUtility.ToJson(content));

            SetUserData(dataDic);
        }

    }



    public void SetUserData(Dictionary<string, string> data)
    {
        var request = new UpdateUserDataRequest() { Data = data, Permission = UserDataPermission.Public };

        PlayFabClientAPI.UpdateUserData(request, (result) =>
        {
            Debug.Log("Update Player Data!");

        }, Debug.Log);
        

    }

    public void DeleteUserData(List<string> deleteKeys)
    {
        var request = new UpdateUserDataRequest() { KeysToRemove = deleteKeys };

        PlayFabClientAPI.UpdateUserData(request, (result) =>
        {
            Debug.Log("Success Delete Data");
        }, Debug.Log);
    }

   /* public void SaveObject()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Object");
        
        //AWSave save = GetComponent<AWSave>();

        objectLength = obj.Length;
        save.FindCountNum(objectLength);
        Debug.Log(obj.Length);
        for(int i =0; i < obj.Length; i++)
        {
            objectName = "Object" + i;

            ObjectController OC = obj[i].GetComponent<ObjectController>();

            prefabTypeNum = OC.prefabTypeNum;
            objectScale = obj[i].transform.localScale.x;
            objectPositionX = obj[i].transform.position.x;
            objectPositionY = obj[i].transform.position.y;
            objectPositionZ = obj[i].transform.position.z;
            objectRotateX = obj[i].transform.localEulerAngles.x;
            objectRotateY = obj[i].transform.localEulerAngles.y;
            objectRotateZ = obj[i].transform.localEulerAngles.z;
            objectRotateSpeed = OC.speed;
            save.SaveObject(i);
        }
    }*/
}


