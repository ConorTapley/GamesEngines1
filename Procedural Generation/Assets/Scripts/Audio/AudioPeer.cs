using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPeer : MonoBehaviour
{
    static AudioSource audioSource;
    public static float[] samples = new float[512];

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    
    void Update()
    {
        GetSpectrumAudioSource();
    }


    public void GetSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman); //<--------converting the 20,000 samples into the amount of samples in the sample array
    }
}
