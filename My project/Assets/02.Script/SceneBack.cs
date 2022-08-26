using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneBack : MonoBehaviour
{
   public void BackScene()
   {
        SceneManager.LoadScene("01.Scenes/04.Show");
   }
}
