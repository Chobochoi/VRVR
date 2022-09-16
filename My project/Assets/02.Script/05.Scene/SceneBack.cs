using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;


public class SceneBack : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void OnExitClick()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("01.Scenes/04.Show");
    }
}
