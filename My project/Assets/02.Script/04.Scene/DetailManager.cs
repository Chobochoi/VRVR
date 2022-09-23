using Photon.Pun;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DetailManager : MonoBehaviourPunCallbacks
{
    //public float rayDistance = 30.0f;
    //public RaycastHit[] hitData;
    public Button btn;


    public void Update()
    {
        switch (btn.name)
        {
            case "Button1":
                SceneManager.LoadScene("01.Scenes/04.Detail1");
                break;
            case "Button2":
                SceneManager.LoadScene("01.Scenes/04.Detail2");
                break;
            case "Button3":
                SceneManager.LoadScene("01.Scenes/04.Detail3");
                break;
            case "Button4":
                SceneManager.LoadScene("01.Scenes/04.Detail4");
                break;
        }
    }
    //public void DetailLoader()
    //{
    //    //Ray ray = new Ray(transform.position, transform.forward * rayDistance);

    //    //hitData = Physics.RaycastAll(transform.position, transform.forward, 100.0f);

    //    //if (Physics.RaycastAll(transform.position, transform.forward, Mathf.Infinity, LayerMask.GetMask("UI")));
    //    //foreach (var item in hitData)
    //    //{
    //        switch (btn.name)
    //        {
    //            case "Button1":                    
    //                SceneManager.LoadScene("01.Scenes/04.Detail1");
    //                break;
    //            case "Button2":
    //                SceneManager.LoadScene("01.Scenes/04.Detail2");
    //                break;
    //            case "Button3":
    //                SceneManager.LoadScene("01.Scenes/04.Detail3");
    //                break;
    //            case "Button4":
    //                SceneManager.LoadScene("01.Scenes/04.Detail4");
    //                break;

    //                DontDestroyOnLoad(gameObject);
    //        }
    //    //}       

    //}
}



    
