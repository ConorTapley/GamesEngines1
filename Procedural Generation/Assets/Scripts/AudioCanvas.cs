﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioCanvas : MonoBehaviour
{
    public bool panelsOn = true;

    public AudioPlanet ap;
    private float intensity;
    private float resolution;

    public AudioSource audioSource;
    [SerializeField] AudioClip youAndI;
    [SerializeField] AudioClip kidsSeeGhosts;

    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject changeSongPanel;

    private string volumeString;
    public Text volumeText;
    private string pitchString;
    public Text pitchText;
    private string intensityString;
    public Text intensityText;
    private string resolutionString;
    public Text resolutionText;

    void Awake()
    {
        if(panelsOn)
        {
            mainPanel.SetActive(true);
            changeSongPanel.SetActive(false);
        }
        else
        {
            mainPanel.SetActive(false);
            changeSongPanel.SetActive(false);
        }
    }

    private void Start()
    {
        volumeString = "70";
        pitchString = "1";
        intensityString = "2";
        resolutionString = "150";
    }

    void Update()
    {
        volumeText.text = volumeString + "%";
        pitchText.text = pitchString;
        intensityText.text = intensityString;

        //ap.intensity = intensity;
        intensity = ap.intensity;
        ap.resolution = resolution;
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

    
    public void Intensity(float sliderValue)
    {
        intensity = sliderValue;
        intensityString = sliderValue.ToString("f0");
    }
    
    public void Resolution(float sliderValue)
    {
        resolution = sliderValue;
        resolutionString = sliderValue.ToString();
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
