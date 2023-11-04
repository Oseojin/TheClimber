using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation : MonoBehaviour
{
    private enum PlayerRate
    { }
    private enum PlayerJob
    { }
    private enum PlayerGrace
    { }

    [SerializeField] private string playerNickName;
    [SerializeField] private PlayerRate playerRate;
    [SerializeField] private int playerLevel;
    [SerializeField] private PlayerJob playerJob;
    [SerializeField] private List<int> playerRuneList;
    [SerializeField] private PlayerGrace playerGrace;

    [SerializeField] private int playerStrength = 1;
    [SerializeField] private int playerIntelligence = 1;
    [SerializeField] private int playerAgility = 1;
    [SerializeField] private int playerLuck = 1;
    [SerializeField] private int playerHiddenStat;

    [SerializeField] private List<int> playerSkillList;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public int GetPlayerStrength()
    {
        return playerStrength;
    }

    public int GetPlayerIntelligence()
    {
        return playerIntelligence;
    }

    public int GetPlayerAgility()
    {
        return playerAgility;
    }

    public int GetPlayerLuck()
    {
        return playerLuck;
    }

    public int GetPlayerHiddenStat()
    {
        return playerHiddenStat;
    }
}
