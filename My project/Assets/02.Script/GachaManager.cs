using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GachaManager : MonoBehaviour
{

    System.Random ran;
    [SerializeField] GameObject light;
    public GameObject spawnPos;
    [SerializeField] TMP_Text text;
    [SerializeField] Animation anim;
    [SerializeField] CanvasGroup cg;
    [SerializeField] ParticleSystem part;
    
   string[] gift =
   {
        "토끼",
        "고양이",
        "강아지",
        "개구리",
        "판다",
        "악어",
        "거북이",
        "하마",
        "북극곰",
        "호랑이",
        "말레이언",
        "카멜레온",
        "코끼리",
        "사자",
        "양",
        "돼지",
        "생쥐",
        "레서판다",
        "코알라",
        "그린 도롱뇽",
        "핑크 도롱뇽",
        "다람쥐",
        "고슴도치",
        "블루상어",
        "그레이상어",
        "고래상어",
        "돌고래",
        "범고래",
        "고래",
        "수달",
        "흰동가리",
        "오리",
        "듀공",
        "물개",
        "펭귄",
        "황제펭귄"
   };  
   

    void Start()
    {
        ran = new System.Random();
        light.SetActive(false);
        cg.alpha = 0;
    }


    void Update()
    {
        
    }

    public void Luck()
    {
        int num = ran.Next(gift.Length);
        text.text = gift[num];

        float time = 0;
        while (time <= 1)
        {
            time += (Time.unscaledDeltaTime / 10000);
            cg.alpha = Mathf.Lerp(0f, 1.0f, time);
        }

        light.SetActive(true);
        anim.Play();
        part.Play();        
    }
}
