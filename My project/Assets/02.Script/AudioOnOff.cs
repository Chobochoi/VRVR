using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioOnOff : MonoBehaviour
{
    [SerializeField] AudioClip audio;
    [SerializeField] Button stnBtn;
    [SerializeField] Button endBtn;
    
    void Start()
    {
        audio = GetComponent<AudioClip>();
        stnBtn = GetComponent<Button>();
        endBtn = GetComponent<Button>();
    }

    void Update()
    {
        
    }
}
