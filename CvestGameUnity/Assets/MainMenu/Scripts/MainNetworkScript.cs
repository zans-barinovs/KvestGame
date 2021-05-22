using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
public class MainNetworkScript : MonoBehaviourPunCallbacks 
{
    public GameObject PlayerNickNameObject;
    private string PlayerNickName;
    public GameObject RoomIDObject;
    private string RoomID;

    public string GameLevel; //уровень в игре. В нашем случае название квеста.

    private void Start() 
    {
        PhotonNetwork.NickName = "Player" + Random.Range(1,20);     

        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1.0";
        PhotonNetwork.ConnectUsingSettings();   

        GameLevel = "Cvest1EscapePrison";
    }

    private void Update() 
    {
        PlayerNickName = PlayerNickNameObject.GetComponent<InputField>().text;
        if (!(PlayerNickName == null || PlayerNickName == ""))
        {
            PhotonNetwork.NickName = PlayerNickName;
            Debug.Log("PlayerNickName: " + PlayerNickName);
        }

        RoomID = RoomIDObject.GetComponent<InputField>().text;
        Debug.Log("RoomID: " + RoomID);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("ConnectedToMaster");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");

        // PhotonNetwork.LoadLevel(GameLevel);
        PhotonNetwork.LoadLevel();
    }

    public void JoinOrCreateRoom()
    {
        try
        {
            // PhotonNetwork.JoinRoom(RoomID);
            PhotonNetwork.JoinRandomRoom();
        }
        catch (System.Exception)
        {
            // PhotonNetwork.CreateRoom(RoomID, new Photon.Realtime.RoomOptions{ MaxPlayers = 2});
            PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions{ MaxPlayers = 2});
        }
    }
}
