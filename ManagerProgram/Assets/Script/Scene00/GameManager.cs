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
 
    public string userID;
    public string storeName;
    public int storeNum;
    public bool storeNameSecondChange = false;
    public int selectObjectNumber = -1;
    public GameObject selectedObj;


}
