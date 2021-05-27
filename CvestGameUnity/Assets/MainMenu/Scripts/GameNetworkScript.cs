using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameNetworkScript : MonoBehaviourPunCallbacks
{
    public GameObject FirstMainCharacter;
    public GameObject FirstMainCharacterSpawnPoint;

    private void Start() 
    {
        PhotonNetwork.Instantiate(FirstMainCharacter.name, FirstMainCharacterSpawnPoint.transform.position, Quaternion.identity, 0); //видео 15:13 Указать название игрока и его координаты спауна для руна.
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom() //вызывается когда этот игролк покидает комнату.
    {
        SceneManager.LoadScene(0);
        Debug.Log("This Player left room");
    }

    public override void OnPlayerEnteredRoom(Player NewPlayer)
    {
        Debug.LogFormat("Player {0} entered room", NewPlayer.NickName);
    }

    public override void OnPlayerLeftRoom(Player LeftPlayer)
    {
        Debug.LogFormat("Player {0} left room", LeftPlayer.NickName);
    }
}