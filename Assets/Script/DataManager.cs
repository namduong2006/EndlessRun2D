using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    public static int Coins
    {
        get { return PlayerPrefs.GetInt("Coin", 0); }
        set { PlayerPrefs.SetInt("Coin", value); }
    }
    
}
