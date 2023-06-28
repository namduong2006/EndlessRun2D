using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource sound;
    [SerializeField] Slider volumMusic;
    [SerializeField] Slider volumeSound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        music.volume = volumMusic.value;
        sound.volume = volumeSound.value;
    }  
}
