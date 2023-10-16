using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public static Music Instance;
    [SerializeField] private AudioSource music;    
    [SerializeField] private AudioClip[] sounds;
    AudioSource sound;
    private void Awake()
    {
        Instance = this;       
    }
    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }
    public void SetVolumSound(float volumsound)
    {
        sound.volume = volumsound;
        Data.Instance.VolSound = volumsound;
    }
    public void SetVolumMusic(float volum)
    {
        music.volume = volum;
        Data.Instance.VolMusic = volum;
    }
    public void SoundCoin()
    {
        sound.clip = sounds[0];
        sound.Play();
    }
    public void SoundGameOver()
    {
        music.Stop();
        sound.clip = sounds[1];
        sound.Play();
    }
}
