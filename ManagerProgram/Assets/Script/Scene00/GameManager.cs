using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;



public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        #region 싱글톤
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        #endregion    
    }
    #region 변수 모음 


    //GameManager 변
    public GameObject selectedObj;
    public int selectObjectNumber = -1;
    public bool storeNameSecondChange = false;
    public List<string> instanceName = new List<string>();

    //Scene0 변수 
    public string userID;

    //Scene1 변수
    public string storeName;
    public int storeNum;

    //Scene2 변수
    public int objectCount;
    public string objectName;
  
    public int prefabTypeNum;
    public int value;

    public float objectPositionX;
    public float objectPositionY;
    public float objectPositionZ;

    public float objectRotateX;
    public float objectRotateY;
    public float objectRotateZ;

    public float objectScale;

    public float objectRotateSpeed;

    //선택된 오브젝트 이름, 위치, 회전, 로테이션값, 스케일값
    #endregion

    public void SaveOBJ()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Object");
        objectCount = obj.Length;
        for (int i = 0; i < obj.Length; i++)
        {
            //obj[i] = GetComponent<GameObject>();
            ObjectController objbase = obj[i].GetComponent<ObjectController>();
            
            objectName = obj[i].name;
            prefabTypeNum = objbase.prefabTypeNum;
            value = objbase.value;

            objectPositionX = obj[i].transform.position.x;
            objectPositionY = obj[i].transform.position.y;
            objectPositionZ = obj[i].transform.position.z;
            objectRotateX = obj[i].transform.eulerAngles.x;
            objectRotateY = obj[i].transform.eulerAngles.y;
            objectRotateZ = obj[i].transform.eulerAngles.z;
            objectScale = obj[i].transform.localScale.x;
            objectRotateSpeed = objbase.speed;

            Debug.Log(obj.Length);
            AWSave save = GetComponent<AWSave>();
            save.SaveObject(i);
        }
    }
}
