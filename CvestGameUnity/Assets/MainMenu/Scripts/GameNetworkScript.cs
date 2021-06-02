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

    private int UpdateCounter = 0;

    private Camera FirstMainCharacterCamera;
    private Camera SecondMainCharacterCamera;

    private bool SomeoneEnteredRoom = false;

    private void Start() 
    {
        
    }

    private void Update() {
        UpdateCounter++;
        if (UpdateCounter == 2)
        {
            if (GameObject.FindGameObjectWithTag("FirstMainCharacter") == null)
            {
                Debug.Log("FirstMainCharacter not exists");
                FirstMainCharacterExists = false;
            }

            if (!FirstMainCharacterExists)
            {
                Debug.Log("spawn FirstMainChar");
                PhotonNetwork.Instantiate(FirstMainCharacter.name, FirstMainCharacterSpawnPoint.transform.position, Quaternion.identity, 0);
            }
            else
            {
                Debug.Log("spawn SecondMainCharacter");
                PhotonNetwork.Instantiate(SecondMainCharacter.name, SecondMainCharacterSpawnPoint.transform.position, Quaternion.identity, 0);
            }

            if (FirstMainCharacterExists)
            {
                FirstMainCharacterCamera = GameObject.FindGameObjectWithTag("FirstMainCharacterCamera").GetComponent<Camera>() as Camera;
                SecondMainCharacterCamera = GameObject.FindGameObjectWithTag("SecondMainCharacterCamera").GetComponent<Camera>() as Camera;

                SecondMainCharacterCamera.enabled = true;
                FirstMainCharacterCamera.enabled = false;
            }
        }
        Debug.Log("update");

        if (SomeoneEnteredRoom && UpdateCounter == 100)
        {
            ChaingeCameraToFirst();
        }
    }

    private async void ChaingeCameraToFirst()
    {
        Debug.Log("SomeoneEnteredRoom && UpdateCounter == 60");
        FirstMainCharacterCamera = GameObject.FindGameObjectWithTag("FirstMainCharacterCamera").GetComponent<Camera>() as Camera;
        SecondMainCharacterCamera = GameObject.FindGameObjectWithTag("SecondMainCharacterCamera").GetComponent<Camera>() as Camera;

        FirstMainCharacterCamera.enabled = true;
        SecondMainCharacterCamera.enabled = false;
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

        SomeoneEnteredRoom = true;
        UpdateCounter = 56;
    }

    public override void OnPlayerLeftRoom(Player LeftPlayer)
    {
        Debug.LogFormat("Player {0} left room", LeftPlayer.NickName);
    }
}