using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBTICount : MonoBehaviour
{
    public int count;

    public void Selected(int i)
    {
        Data.count = i;        
    }
}
