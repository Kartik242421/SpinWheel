using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum GameDiff
{
    Easy,Medium,Hard
}
public class GameModeDDOL : MonoBehaviour
{
    public static GameModeDDOL instance;
    public GameDiff gameDiff;
    public string playerName, email,number;
    public int score;

    public string top, noTop;

    public int puzzleNum;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
