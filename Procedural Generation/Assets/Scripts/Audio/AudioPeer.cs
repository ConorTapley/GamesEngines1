using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPeer : MonoBehaviour
{
    public AudioSource audioSource;
    public static float[] samples = new float[512];
    public static float[] frequencyBands = new float[8]; //<---------making an array of frequency bands to make the audio visuals be more consistant (not huge where the bass is and tiny at the other end)

    void Start()
    {
        //audioSource = this.GetComponent<AudioSource>();
    }

    
    void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
    }


    public void GetSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman); //<--------converting the 20,000 samples into the amount of samples in the sample array
    }

    public void MakeFrequencyBands()
    {
        /*
         * 0-2 (2 Samples at the beginning of the array) = 86 hertz
         * 1-4 (4 Samples in the second element)= 172 hertz - 87-258
         * 2-8 (8 samples in the third)= 344 hertz - 259-602
         * 3-16 (16 samples in the fourth)= 688 hertz - 603-1290
         * 4-32 (32 samples in the fifth)= 1376 hertz - 1291-2666
         * 5-64 (64 samples in the sixth)= 2752 hertz - 2667-5418
         * 6-128 (128 samples in the seventh)= 5504 hertz - 5419-10922
         * 7-256 (256 samples in the eighth)= 11008 hertz - 10923-21930
         * 510 (Samples in total)
         * */

        float average = 0f;
        int count = 0; //<-----calculating the current sample
        for (int i = 0; i < 8; i++)
        {
            int sampleCount = (int)Mathf.Pow(2, i) * 2; //<------ doubling itself evertime 

            if (i == 7)
                sampleCount += 2; //<----- adding 2 samples to the last element of the array because i have 512 samples in total and without this im only calculating 510

            for (int j = 0; j < sampleCount; j++)
            {
                average += samples[count] * count + 1;
                    count++;
            }
            average /= count;
            frequencyBands[i] = average * 10;
        }
    }
}
