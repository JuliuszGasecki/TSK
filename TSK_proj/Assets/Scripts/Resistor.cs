using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resistor : MonoBehaviour, IElectricObject
{
    [SerializeField]
    private double resistRate;
    [SerializeField]
    private double inputVoltage;
    [SerializeField]
    private double inputAmper;

    [SerializeField]
    private double outputVoltage;
    [SerializeField]
    private double outputAmper;

    // interface that contains set voltage method;
    [SerializeField]
    private GameObject nextObject;

    public void SetAmper(double ampers)
    {
        this.inputAmper = ampers;
    }

    public void SetVoltage(double voltage)
    {
        this.inputVoltage = voltage;
    }

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        calculateOutput();
    }

    private void calculateOutput()
    {
        calculateOutputVoltage();
        calculateOutputAmpers();
    }

    private void calculateOutputVoltage()
    {
        this.outputVoltage = inputAmper * resistRate;
    }

    private void calculateOutputAmpers()
    {
        this.outputAmper = inputVoltage / resistRate;
    }

}
