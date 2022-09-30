 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
 
    public bool storeNameSecondChange = false;
    public int selectObjectNumber = -1;
    public GameObject selectedObj;

    public string userID;
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

    public void SaveObject()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Object");
        
        AWSave save = GetComponent<AWSave>();

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
    }

}
