using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaManager : MonoBehaviour
{

    System.Random ran;
    string itemName;
    public GameObject spawnPos;

    void Start()
    {
        ran = new System.Random();
    }


    void Update()
    {

    }

    public void Random()
    {

        itemName = ran.Next(10).ToString();

        GameObject item = Resources.Load<GameObject>(itemName);
        Instantiate(item, spawnPos.transform.position, spawnPos.transform.rotation);
    }
}
