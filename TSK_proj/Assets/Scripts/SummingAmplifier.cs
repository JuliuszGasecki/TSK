using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummingAmplifier : MonoBehaviour
{
    [SerializeField]
    private bool directCurrent;
    [SerializeField]
    private double frequency;
    [SerializeField]
    private double Uo;
    [SerializeField]
    List<double> Uwes;
    [SerializeField]
    private double Uwy;
    [SerializeField]
    List<double> resistors;
    [SerializeField]
    private double Rf;
    [SerializeField]
    private double simulationSpeed;
    // Start is called before the first frame update
    SoundGenerator soundGen;
    void Start()
    {
        soundGen = GameObject.Find("Audio").GetComponent<SoundGenerator>();
        calculateAlternatingCurrent();
        calculateUwy();
        soundGen.setValues(440 + Uwy);
    }

    private void calculateUwy()
    {
        Uwy = -Rf * calculateSumOfRatioOfWeAndR();
    }

    private double calculateSumOfRatioOfWeAndR()
    {
        double sum = 0;
        for(int i = 0; i < resistors.Count; i++)
        {
            sum += Uwes[i] / resistors[i];
        }
        return sum;
    }

    private void calculateAlternatingCurrent()
    {
        for(int i = 0; i < Uwes.Count; i++) {
            Uwes[i] = Uo * Mathf.Sin((1 / (float)frequency) * Time.time * (float)simulationSpeed);
        }  
    }

    // Update is called once per frame
    void Update()
    {
        calculateAlternatingCurrent();
        calculateUwy();
        soundGen.setValues(440 + Uwy);
    }
}
