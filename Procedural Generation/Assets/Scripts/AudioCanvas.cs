using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioCanvas : MonoBehaviour
{
    public bool panelsOn = true;

    public CubeVisualizer cv;
    public AudioPlanet ap;
    private float sIntensity;
    private float cIntensity;
    private float resolution;

    public AudioSource audioSource;
    [SerializeField] private AudioClip youAndI;
    [SerializeField] private AudioClip kidsSeeGhosts;
    [SerializeField] private AudioClip lalala;
    [SerializeField] private AudioClip bonfire;
    [SerializeField] private AudioClip takeWhatUWant;

    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject changeSongPanel;

    private string volumeString;
    public Text volumeText;

    private string pitchString;
    public Text pitchText;

    private string sIntensityString;
    public Text sIntensityText;

    private string cIntensityString;
    public Text cIntensityText;

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
        sIntensityString = "2";
        cIntensityString = "2";
        resolutionString = "150";
        sIntensity = 2;
        cIntensity = 2;
    }

    void Update()
    {
        volumeText.text = volumeString + "%";
        pitchText.text = pitchString;
        sIntensityText.text = sIntensityString;
        cIntensityText.text = cIntensityString;

        cv.maxScale = cIntensity;
        ap.intensity = sIntensity;
        //intensity = ap.intensity;
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

    
    public void Sintensity(float sliderValue)
    {
        sIntensity = sliderValue;
        sIntensityString = sliderValue.ToString("f0");
    }

    public void Cintensity(float sliderValue)
    {
        cIntensity = sliderValue;
        cIntensityString = sliderValue.ToString("f0");
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

    public void Lalala()
    {
        //if the audio source is currently playing a song stop the song before changing to this song
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.clip = lalala;
        audioSource.PlayOneShot(lalala);
    }

    public void TakeWhatUWant()
    {
        //if the audio source is currently playing a song stop the song before changing to this song
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.clip = takeWhatUWant;
        audioSource.PlayOneShot(takeWhatUWant);
    }

    public void Bonfire()
    {
        //if the audio source is currently playing a song stop the song before changing to this song
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.clip = bonfire;
        audioSource.PlayOneShot(bonfire);
    }
}
