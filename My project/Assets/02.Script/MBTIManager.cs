using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MBTIManager : MonoBehaviour
{
    public TMP_Text MBTItext;

    void Start()
    {
        
    }

    void Update()
    {
        switch (Data.count)
        {
            case 0:
                MBTItext.text = "ISTJ의 오늘의 운세";
                break;
            case 1:
                MBTItext.text = "ISFJ의 오늘의 운세";
                break;
            case 2:
                MBTItext.text = "INFJ의 오늘의 운세";
                break;
            case 3:
                MBTItext.text = "INTJ의 오늘의 운세";
                break;
            case 4:
                MBTItext.text = "ISTP의 오늘의 운세";
                break;
            case 5:
                MBTItext.text = "ISFP의 오늘의 운세";
                break;
            case 6:
                MBTItext.text = "INFP의 오늘의 운세";
                break;
            case 7:
                MBTItext.text = "INTP의 오늘의 운세";
                break;
            case 8:
                MBTItext.text = "ESTP의 오늘의 운세";
                break;
            case 9:
                MBTItext.text = "ESFP의 오늘의 운세";
                break;
            case 10:
                MBTItext.text = "ENFP의 오늘의 운세";
                break;
            case 11:
                MBTItext.text = "ENTP의 오늘의 운세";
                break;
            case 12:
                MBTItext.text = "ESTJ의 오늘의 운세";
                break;
            case 13:
                MBTItext.text = "ESFJ의 오늘의 운세";
                break;
            case 14:
                MBTItext.text = "ENFJ의 오늘의 운세";
                break;
            case 15:
                MBTItext.text = "ENTJ의 오늘의 운세";
                break;
        }
    }
}
