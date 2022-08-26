using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetailManager : MonoBehaviour
{   
    public void DetailLoader()
    {
        switch(this.gameObject.name)
        {
        case "Detail Button1":
        SceneManager.LoadScene("01.Scenes/05.Detail1");
        break;
        case "Detail Button2":
        SceneManager.LoadScene("01.Scenes/05.Detail2");
        break;
        case "Detail Button3":
        SceneManager.LoadScene("01.Scenes/05.Detail3");
        break;
        case "Detail Button4":
        SceneManager.LoadScene("01.Scenes/05.Detail4");
        break;
        }
    }
}
