using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetailManager : MonoBehaviour
{   
    public void DetailLoader(string detailName)
    {
        SceneManager.LoadScene("01.Scenes/05.Detail1");
    }
}
