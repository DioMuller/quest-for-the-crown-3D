using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class PlayerData : ScriptableObject
{
    public CharacterData CharacterData;
    public int CurrentHealth;
    public int CurrentMagic;
    public bool[] ObtainedWeapons;
}

public class GlobalPlayerData 
{
    private List<PlayerData> _players = new List<PlayerData>();

    public PlayerData[] GetPlayers()
    {
        return _players.ToArray();
    }

    public void CreatePlayer(CharacterData characterData)
    {
        PlayerData data = new PlayerData
        {
            CharacterData = characterData,
            CurrentHealth = characterData.MaxHealth,
            CurrentMagic = characterData.MaxMagic,
            ObtainedWeapons = new bool[]{true, false, false, false}
        };

        _players.Add(data);
    }

    public void LoadPlayer(PlayerData player)
    {
        _players.Add(player);
    }

    public void AddPlayer(PlayerData player)
    {
        PlayerData data = new PlayerData
        {
            CharacterData = player.CharacterData,
            CurrentHealth = player.CurrentHealth,
            CurrentMagic = player.CurrentMagic,
            ObtainedWeapons = player.ObtainedWeapons
        };
    }

    public int RemovePlayer()
    {
        if (_players.Count <= 0) return 0;

        _players.RemoveAt(0);
        return _players.Count;
    }

    public void UpdateData(CharacterStatus[] characters, WeaponStatus[] weapons)
    {
        if( characters.Length != _players.Count || characters.Length == 0 )
        {
            Debug.LogError("Invalid Character Array Size! Aborting.");
            return;
        }

        bool[] activeWeapons = weapons.Select(w => w.WeaponEnabled).ToArray();

        for(int i = 0; i < characters.Length; i++)
        {
            _players[i] = new PlayerData
            {
                CharacterData = characters[i].Data,
                CurrentHealth = characters[i].CurrentHealth,
                CurrentMagic = characters[i].CurrentMagic,
                ObtainedWeapons = activeWeapons
            };
        }
    }
}
