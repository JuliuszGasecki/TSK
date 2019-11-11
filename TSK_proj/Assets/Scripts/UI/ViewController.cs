using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ViewController : MonoBehaviour
{
    GameObject simulator;
    GameObject ampImg;

    public Text Uwo;
    public Text Uwe;
    public Text Uwy;

    public List<Sprite> sprites;

    // Start is called before the first frame update
    void Start()
    {
        simulator = GameObject.Find("Simulator");
        ampImg = GameObject.Find("AmpImage");
        SetAmp(0);
    }

    public void SetAmp(int val)
    {
        ampImg.GetComponent<Image>().sprite = sprites[val];
        if (val == 0)
        {
            simulator.GetComponent<InvertingAmplifier>().enabled = true;
            simulator.GetComponent<NonInvertingAmplifier>().enabled = false;
            simulator.GetComponent<SummingAmplifier>().enabled = false;
            simulator.GetComponent<IntegralAmplifier>().enabled = false;
            simulator.GetComponent<DifferentialAmplifier>().enabled = false;
        }
        else if (val == 1)
        {
            simulator.GetComponent<InvertingAmplifier>().enabled = false;
            simulator.GetComponent<NonInvertingAmplifier>().enabled = true;
            simulator.GetComponent<SummingAmplifier>().enabled = false;
            simulator.GetComponent<IntegralAmplifier>().enabled = false;
            simulator.GetComponent<DifferentialAmplifier>().enabled = false;
        }
        else if (val == 2)
        {
            simulator.GetComponent<InvertingAmplifier>().enabled = false;
            simulator.GetComponent<NonInvertingAmplifier>().enabled = false;
            simulator.GetComponent<SummingAmplifier>().enabled = true;
            simulator.GetComponent<IntegralAmplifier>().enabled = false;
            simulator.GetComponent<DifferentialAmplifier>().enabled = false;
        }
        else if (val == 3)
        {
            simulator.GetComponent<InvertingAmplifier>().enabled = false;
            simulator.GetComponent<NonInvertingAmplifier>().enabled = false;
            simulator.GetComponent<SummingAmplifier>().enabled = false;
            simulator.GetComponent<IntegralAmplifier>().enabled = true;
            simulator.GetComponent<DifferentialAmplifier>().enabled = false;
        }
        else if (val == 4)
        {
            simulator.GetComponent<InvertingAmplifier>().enabled = false;
            simulator.GetComponent<NonInvertingAmplifier>().enabled = false;
            simulator.GetComponent<SummingAmplifier>().enabled = false;
            simulator.GetComponent<IntegralAmplifier>().enabled = false;
            simulator.GetComponent<DifferentialAmplifier>().enabled = true;
        }
    }

    public void SetUwo(float val)
    {
        if (simulator.GetComponent<InvertingAmplifier>().enabled)
        {
            simulator.GetComponent<InvertingAmplifier>().SetUwo(val);
        }
        if (simulator.GetComponent<NonInvertingAmplifier>().enabled)
        {
            simulator.GetComponent<NonInvertingAmplifier>().SetUwo(val);
        }
        if (simulator.GetComponent<SummingAmplifier>().enabled)
        {
            simulator.GetComponent<SummingAmplifier>().SetUwo(val);
        }
        if (simulator.GetComponent<IntegralAmplifier>().enabled)
        {
            simulator.GetComponent<IntegralAmplifier>().SetUwo(val);
        }
        if (simulator.GetComponent<DifferentialAmplifier>().enabled)
        {
            simulator.GetComponent<DifferentialAmplifier>().SetUwo(val);
        }
    }

    public void SetSimulationSpeed(float val)
    {
        if (simulator.GetComponent<InvertingAmplifier>().enabled)
        {
            simulator.GetComponent<InvertingAmplifier>().SetSimulationSpeed(val);
        }
        if (simulator.GetComponent<NonInvertingAmplifier>().enabled)
        {
            simulator.GetComponent<NonInvertingAmplifier>().SetSimulationSpeed(val);
        }
        if (simulator.GetComponent<SummingAmplifier>().enabled)
        {
            simulator.GetComponent<SummingAmplifier>().SetSimulationSpeed(val);
        }
        if (simulator.GetComponent<IntegralAmplifier>().enabled)
        {
            simulator.GetComponent<IntegralAmplifier>().SetSimulationSpeed(val);
        }
        if (simulator.GetComponent<DifferentialAmplifier>().enabled)
        {
            simulator.GetComponent<DifferentialAmplifier>().SetSimulationSpeed(val);
        }
    }

    public void SetText()
    {
        if (simulator.GetComponent<InvertingAmplifier>().enabled)
        {
            this.Uwo.text = simulator.GetComponent<InvertingAmplifier>().GetUwo().ToString();
            this.Uwe.text = simulator.GetComponent<InvertingAmplifier>().GetUwe().ToString();
            this.Uwy.text = simulator.GetComponent<InvertingAmplifier>().GetUwy().ToString();
        }
        else if (simulator.GetComponent<NonInvertingAmplifier>().enabled)
        {
            this.Uwo.text = simulator.GetComponent<NonInvertingAmplifier>().GetUwo().ToString();
            this.Uwe.text = simulator.GetComponent<NonInvertingAmplifier>().GetUwe().ToString();
            this.Uwy.text = simulator.GetComponent<NonInvertingAmplifier>().GetUwy().ToString();
        }
        else if (simulator.GetComponent<SummingAmplifier>().enabled)
        {
            this.Uwo.text = simulator.GetComponent<SummingAmplifier>().GetUwo().ToString();
            this.Uwe.text = simulator.GetComponent<SummingAmplifier>().GetUwe().ToString();
            this.Uwy.text = simulator.GetComponent<SummingAmplifier>().GetUwy().ToString();
        }
        else if (simulator.GetComponent<IntegralAmplifier>().enabled)
        {
            this.Uwo.text = simulator.GetComponent<IntegralAmplifier>().GetUwo().ToString();
            this.Uwe.text = simulator.GetComponent<IntegralAmplifier>().GetUwe().ToString();
            this.Uwy.text = simulator.GetComponent<IntegralAmplifier>().GetUwy().ToString();
        }
        else if (simulator.GetComponent<DifferentialAmplifier>().enabled)
        {
            this.Uwo.text = simulator.GetComponent<DifferentialAmplifier>().GetUwo().ToString();
            this.Uwe.text = simulator.GetComponent<DifferentialAmplifier>().GetUwe().ToString();
            this.Uwy.text = simulator.GetComponent<DifferentialAmplifier>().GetUwy().ToString();
        }
    }
    // Update is called once per frame
    void Update()
    {
        SetText();
    }
}
