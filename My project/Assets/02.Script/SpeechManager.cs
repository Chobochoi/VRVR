using FrostweepGames.Plugins.GoogleCloud.SpeechRecognition;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json.Linq;

public class SpeechManager : MonoBehaviour
{
    Button buttonStart;
    Button buttonEnd;
    TMP_Text txtresulte;
    [SerializeField]
    Dropdown languageDrop;

    GCSpeechRecognition speechRec;

    public AudioSource audioSource;

    public string text;

    void Start()
    {

        speechRec = GCSpeechRecognition.Instance;

        speechRec.FinishedRecordEvent += OnFinishedRecordEvent;
        speechRec.RecognizeSuccessEvent += OnRecognizeSuccessEvent;


        if (speechRec.HasConnectedMicrophoneDevices())
            speechRec.SetMicrophoneDevice(speechRec.GetMicrophoneDevices()[0]);

        languageDrop.ClearOptions();

        for (int i = 0; i < Enum.GetNames(typeof(Enumerators.LanguageCode)).Length; i++)
        {
            languageDrop.options.Add(new Dropdown.OptionData(((Enumerators.LanguageCode)i).Parse()));
        }

        languageDrop.value = languageDrop.options.IndexOf(languageDrop.options.Find(x => x.text == Enumerators.LanguageCode.ko_KR.Parse()));

        audioSource = gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnButtonStartClick()
    {
        speechRec.StartRecord(false);
    }
    public void OnButtonStopClick()
    {
        speechRec.StopRecord();
    }
    private void OnDestroy()
    {
        speechRec.FinishedRecordEvent -= OnFinishedRecordEvent;
        speechRec.RecognizeSuccessEvent -= OnRecognizeSuccessEvent;
    }

    private void OnRecognizeSuccessEvent(RecognitionResponse recognitionResponse)
    {
        string r = "";

        foreach (var result in recognitionResponse.results)
        {
            foreach (var alternative in result.alternatives)
            {
                if (recognitionResponse.results[0].alternatives[0] != alternative)
                {
                    r = alternative.transcript;
                }
            }
        }
        Debug.Log(r);

        if (String.IsNullOrWhiteSpace(r))
        {
            return;
        }



        string url = "https://openapi.naver.com/v1/papago/n2mt";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Headers.Add("X-Naver-Client-Id", "srvkcptxXDYEbhFn0flL");
        request.Headers.Add("X-Naver-Client-Secret", "5Z4LfhHB6P");
        request.Method = "POST";
        //string query = "오늘 날씨는 어떻습니까?";
        byte[] byteDataParams = Encoding.UTF8.GetBytes("source=ko&target=en&text=" + r);
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = byteDataParams.Length;
        Stream st = request.GetRequestStream();
        st.Write(byteDataParams, 0, byteDataParams.Length);
        st.Close();
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream stream = response.GetResponseStream();
        StreamReader reader = new StreamReader(stream, Encoding.UTF8);
        string text = reader.ReadToEnd();
        stream.Close();
        response.Close();
        reader.Close();
        //Console.WriteLine(text);

        JObject ret = JObject.Parse(text);
        Debug.Log(ret["message"]["result"]["translatedText"].ToString());

        //jObj = ret["message"]["result"]["translatedText"].ToString();

        //Debug.Log(text);
        StartCoroutine(DownloadTheAudio(ret["message"]["result"]["translatedText"].ToString()));
    }

    private void OnFinishedRecordEvent(AudioClip clip, float[] raw)
    {
        if (clip == null) return;

        RecognitionConfig config = RecognitionConfig.GetDefault();
        config.languageCode = ((Enumerators.LanguageCode)languageDrop.value).Parse();

        config.audioChannelCount = clip.channels;

        GeneralRecognitionRequest recognitionRequest = new GeneralRecognitionRequest()
        {
            audio = new RecognitionAudioContent()
            {
                content = raw.ToBase64()
            },
            config = config
        };

        speechRec.Recognize(recognitionRequest);
    }

    IEnumerator DownloadTheAudio(string temp)
    {
        string url = $"https://translate.google.com/translate_tts?ie=UTF-8&total=1&idx=0&textlen=32&client=tw-ob&q={temp}&tl=En-gb";
        WWW www = new WWW(url);
        yield return www;

        audioSource.clip = www.GetAudioClip(false, true, AudioType.MPEG);
        audioSource.Play();
    }
}