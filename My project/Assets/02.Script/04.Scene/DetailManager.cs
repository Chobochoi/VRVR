using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class DetailManager : MonoBehaviourPunCallbacks
{  
    public void DetailLoader()
    {
        switch(this.gameObject.name)
        {
        case "Button1":
        SceneManager.LoadScene("01.Scenes/05.Detail1");
        break;
        case "Button2":
        SceneManager.LoadScene("01.Scenes/05.Detail2");
        break;
        case "Button3":
        SceneManager.LoadScene("01.Scenes/05.Detail3");
        break;
        case "Button4":
        SceneManager.LoadScene("01.Scenes/05.Detail4");
        break;

        DontDestroyOnLoad(gameObject);
        }
    }

    

    
}
