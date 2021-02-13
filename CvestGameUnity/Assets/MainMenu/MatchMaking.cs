using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

[System.Serializable]
public class Match
{
    public string MatchID;

    public SyncListGameObject players = new SyncListGameObject();

    public Match(string matchID, GameObject player)
    {
        this.MatchID = matchID;
        players.Add(player);
    }

    public Match()
    {

    }
}
[System.Serializable]
public class SyncListGameObject : SyncList<GameObject>
{

}
[System.Serializable]
public class SyncListMatch : SyncList<Match>
{

}



public class MatchMaking : NetworkBehaviour
{
    public static MatchMaking instance;

    public SyncListMatch matches = new SyncListMatch();

    public SyncListString matchIDs = new SyncListString();

    void Start()
    {
        instance = this;
    }



    public bool HostGame(string _matchID, GameObject _player)
    {
        if (!matchIDs.Contains(_matchID))
        {
            matchIDs.Add(_matchID);
            matches.Add(new Match(_matchID, _player));
            Debug.Log($"match generated");
            return true;
        }
        else
        {
            Debug.Log($"Match ID already exists");
            return false;
        }
    }
    public static string GetRandomMatchID()
    {
        string _id = string.Empty;
        for (int i = 0; i < 5; i++)
        {
            int random = Random.Range(0, 36);
            if (random < 26)
            {
                _id += (char)(random + 65);
            }
            else
            {
                _id += (random - 26).ToString();
            }
        }
        Debug.Log($"Random Match Id: {_id}");
        return _id;
    }
}
