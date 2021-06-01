using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameNetworkScript : MonoBehaviourPunCallbacks
{
    public GameObject FirstMainCharacter;
    public GameObject FirstMainCharacterSpawnPoint;
    private bool FirstMainCharacterExists = true;

    public GameObject SecondMainCharacter;
    public GameObject SecondMainCharacterSpawnPoint;


    private void Start() 
    {
        try
        {
            var test = GameObject.FindWithTag("FirstMainCharacter");
        }
        catch (System.Exception)
        {
            
            FirstMainCharacterExists = false;
        }

        if (FirstMainCharacterExists)
        {
            PhotonNetwork.Instantiate(FirstMainCharacter.name, FirstMainCharacterSpawnPoint.transform.position, Quaternion.identity, 0);
        }
        else
        {
            PhotonNetwork.Instantiate(FirstMainCharacter.name, FirstMainCharacterSpawnPoint.transform.position, Quaternion.identity, 0);
        }
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom() //вызывается когда этот игролк покидает комнату.
    {
        
        Application.LoadLevel(0);
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