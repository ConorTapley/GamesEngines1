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

    private string volumeString;
    public Text volumeText;
    private string pitchString;
    public Text pitchText;

    void Awake()
    {
        mainPanel.SetActive(true);
        changeSongPanel.SetActive(false);
    }

    private void Start()
    {
        volumeString = "70";
        pitchString = "1";
    }

    void Update()
    {
        volumeText.text = volumeString + "%";
        pitchText.text = pitchString;
    }

    ////////////////////////////////////////////////Sliders//////////////////////////////////////////////////////
    public void Volume (float sliderValue)
    {
        audioSource.volume = sliderValue;
        float volumeValue = sliderValue * 100;
        volumeString = volumeValue.ToString("f0");
    }

    public void Pitch(float sliderValue)
    {
        audioSource.pitch = sliderValue;
        pitchString = sliderValue.ToString("f1");
    }


    ////////////////////////////////////////////////Buttons//////////////////////////////////////////////////////
    public void ChangeSongButton()
    {
        mainPanel.SetActive(false);
        changeSongPanel.SetActive(true);
    }

    public void BackButton()
    {
        changeSongPanel.SetActive(false);
        mainPanel.SetActive(true);
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
