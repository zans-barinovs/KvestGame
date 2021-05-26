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

    private bool LoadLevelRunning;

    private void Start() 
    {
        PhotonNetwork.NickName = "Player" + Random.Range(1,200);     

        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1.0";
        PhotonNetwork.ConnectUsingSettings();   

        GameLevel = "Cvest1EscapePrison";
        LoadLevelRunning = false;
    }

    private void Update() 
    {
        PlayerNickName = PlayerNickNameObject.GetComponent<InputField>().text;
        if (!(PlayerNickName == null || PlayerNickName == ""))
        {
            PhotonNetwork.NickName = PlayerNickName;
            // Debug.Log("PlayerNickName: " + PlayerNickName);
        }

        RoomID = RoomIDObject.GetComponent<InputField>().text;
        // Debug.Log("RoomID: " + RoomID);
    }



    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");
        if (!LoadLevelRunning && PhotonNetwork.IsMasterClient)
        {
            LoadLevelRunning = true;
            PhotonNetwork.LoadLevel(GameLevel);
        }
    }

    public void CreateRoom()
    {
        Debug.Log("CreateRoom");
        PhotonNetwork.CreateRoom(RoomID, new Photon.Realtime.RoomOptions{ MaxPlayers = 2});
        // PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions{ MaxPlayers = 2});        
    }

    public void JoinRoom()
    {
        Debug.Log("JoinRoom");
        PhotonNetwork.JoinRoom(RoomID);
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby");
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("ConnectedToMaster");
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("OnJoinRoomFailed: " + returnCode + message);
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("OnCreateRoomFailed: " + returnCode + message);
    }
}
