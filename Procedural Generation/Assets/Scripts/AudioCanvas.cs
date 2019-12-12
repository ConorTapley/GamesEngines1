using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioCanvas : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] AudioClip youAndI;
    [SerializeField] AudioClip kidsSeeGhosts;

    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject changeSongPanel;

    void Awake()
    {
        mainPanel.SetActive(true);
        changeSongPanel.SetActive(false);
    }

    
    void Update()
    {
        
    }

    public void Volume (float sliderValue)
    {
        audioSource.volume = sliderValue;
    }

    public void ChangeSongButton()
    {
        mainPanel.SetActive(false);
        changeSongPanel.SetActive(true);
    }

    public void KidsSeeGhosts()
    {
        //if the audio source is currently playing a song stop the song before changing to this song
        if(audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.clip = kidsSeeGhosts;
        audioSource.PlayOneShot(kidsSeeGhosts);
    }

    public void YouAndI()
    {
        //if the audio source is currently playing a song stop the song before changing to this song
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.clip = youAndI;
        audioSource.PlayOneShot(youAndI);
    }
}
