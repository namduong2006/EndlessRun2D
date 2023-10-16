using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static Data Instance;
    private void Awake()
    {
        Instance = this;
    }
    public  int Coins
    {
        get { return PlayerPrefs.GetInt("Coins", 0); }
        set { PlayerPrefs.SetInt("Coins", value); }
    }
    public float VolMusic
    {
        get { return PlayerPrefs.GetFloat("volmusic", 0.5f); }
        set { PlayerPrefs.SetFloat("volmusic", value); }
    }
    public float VolSound
    {
        get { return PlayerPrefs.GetFloat("volsound", 0.5f); }
        set { PlayerPrefs.SetFloat("volsound", value); }
    }
    public int Health
    {
        get { return PlayerPrefs.GetInt("Health", 3); }
        set { PlayerPrefs.SetInt("Health", value); }
    }
}
