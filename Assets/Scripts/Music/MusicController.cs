using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    private Music _music;

    private void Start()
    {
        _music = GetComponentInChildren<Music>();
    }

    public void ChangeMusic(Music.musicType type) 
    {
        _music._musicType = type;
        _music.ListChooser();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            ChangeMusic(Music.musicType.combat);
        }
        if (Input.GetKeyDown(KeyCode.S)) 
        {
            ChangeMusic(Music.musicType.mainMenu);                               // Deneme yeri
        }
        if (Input.GetKeyDown(KeyCode.D)) 
        {
            ChangeMusic(Music.musicType.credits);
        }
    }      
}
