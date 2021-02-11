using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UILobby : MonoBehaviour
{
    [SerializeField] InputField joinInput;
    [SerializeField] Button joinButton;
    [SerializeField] Button hostButton;
    public void Host()
    {
        joinInput.interactable = false;
        joinButton.interactable = false;
        hostButton.interactable = false;

        Player_Lobby.localPlayer.HostGame();
    }
    public void Join()
    {
        joinInput.interactable = false;
        joinButton.interactable = false;
        hostButton.interactable = false;
    }
}   
