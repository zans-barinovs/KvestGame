using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;



public class Player_Lobby : NetworkBehaviour
{
    public static Player_Lobby localPlayer;

    void Start()
    {
        if (isLocalPlayer)
        {
            localPlayer = this;
        }
    }
    public void HostGame()
    {
        string matchId = MatchMaking.GetRandomMatchID();
        CmdHostGame(matchId);
    }
    [Command]
    void CmdHostGame(string _matchID)
    {
        if (MatchMaking.instance.HostGame(_matchID, gameObject))
        {
            Debug.Log($"<color = green>Game hosted successfully</color>");
        }
        else
        {
            Debug.Log($"<color = red>Game not hosted</color>");
        }
    }
}
   