using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerStatus : MonoBehaviour
{   
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void SaveLevel(int PlayersLevel)
    {
        PlayerPrefs.SetInt("PlayerLevel", PlayersLevel);
    }
    public int GetLevel()
    {
        return PlayerPrefs.GetInt("PlayerLevel");
    }
    public void SetAutoRun(int isRunnerAuto)
    {
        PlayerPrefs.SetInt("RunnerAuto", isRunnerAuto);
    }
    public bool GetAutoRun()
    {
        if(PlayerPrefs.GetInt("RunnerAuto",0)==0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
