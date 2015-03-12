using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PlayerManager : SingletonBehaviour<PlayerManager>
{
    private static int playerCount = 0;

    private List<PlayerRegister> _players = new List<PlayerRegister>();

    public bool RegisterPlayer( PlayerRegister playerData )
    {
        if (playerNumber > playerCount || playerNumber < 0) return false;
        if( _players.Contains(playerData) ) return true;
        if( _players.Count( p => p.PlayerNumber == playerData.PlayerNumber ) return false;

        return _players.Add(playerData);
    }

    public bool KillPlayer( PlayerRegister playerData )
    {
        return _players.Remove(playerData);
    }

    public void AddPlayer()
    {
        if (playerCount >= 2) return;
        else playerCount++;
    }
}
