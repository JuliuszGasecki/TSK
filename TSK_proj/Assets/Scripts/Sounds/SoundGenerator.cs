using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundGenerator : MonoBehaviour
{
    public double soundFrequancy;
    private double increment;
    private double phase;
    private double samplingFrequency = 48000;
    public float gain;
    private double SinValue;
    public float volume;

    public void setValues(double freq)
    {
        soundFrequancy = freq;
    }

    private void OnAudioFilterRead(float[] data, int channels)
    {
        increment = soundFrequancy * 2.0 * Mathf.PI / samplingFrequency;
        for(int i = 0; i < data.Length; i += channels)
        {
            phase += increment;
            data[i] = (float)(gain * Mathf.Sin((float)phase));

            if(channels == 2)
            {
                data[i + 1] = data[i];
            }
            if(phase > (Mathf.PI * 2))
            {
                phase = 0.0;
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
