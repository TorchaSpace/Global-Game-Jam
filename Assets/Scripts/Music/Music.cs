using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private List<AudioClip> combatMusics;
    [SerializeField] private List<AudioClip> mainMenuMusics;
    [SerializeField] private List<AudioClip> creditsMusics;
    [SerializeField] private float musicDelay;
    private List<AudioClip> chosenMusics;
    public enum musicType { combat, mainMenu, credits }
    public musicType _musicType;
    private AudioSource _audioSource;
    private AudioClip _chosenMusic;
    private int _currentMusicIndex;

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void MusicController()
    {
        ChooseMusic();
        PlayMusic();
    }
   
    private void ChooseMusic()
    {
        if (chosenMusics.Count == 1) 
        {
            _chosenMusic = chosenMusics[0];
        }
        else 
        {
            int random = Random.Range(0, chosenMusics.Count);
            if (_currentMusicIndex != random)
            {
                _currentMusicIndex = random;
                _chosenMusic = chosenMusics[_currentMusicIndex];
            }
            else
            {
                ChooseMusic();
            }
        }
    }
    private void PlayMusic()
    {
        _audioSource.clip = _chosenMusic;
        _audioSource.Play();
    }
    public void ListChooser()
    {
        _audioSource.Stop();
        StopCoroutine(Timer());

        switch (_musicType)
        {
            case musicType.combat:
                chosenMusics = combatMusics;
                break;
            case musicType.mainMenu:
                chosenMusics = mainMenuMusics;
                break;
            case musicType.credits:
                chosenMusics = creditsMusics;
                break;
        }

        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(musicDelay);
            MusicController();
            yield return new WaitForSeconds(_audioSource.clip.length);

        }
    }

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _audioSource.Stop();                            // Deneme yeri
            StopCoroutine(Timer());
            StartCoroutine(Timer());
        }
    }*/
}
