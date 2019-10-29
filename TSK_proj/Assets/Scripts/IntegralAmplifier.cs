using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntegralAmplifier : MonoBehaviour
{
    [SerializeField]
    private bool directCurrent;
    [SerializeField]
    private double frequency;
    [SerializeField]
    private double Uo;
    [SerializeField]
    private double Uwe;
    [SerializeField]
    private double Uwy;
    [SerializeField]
    private double R1;
    [SerializeField]
    private double R2;
    [SerializeField]
    private double K;
    [SerializeField]
    private double capacitor;
    [SerializeField]
    private double simulationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        calculateAlternatingCurrent();
        calculateUwy();
    }


    private void calculateUwy()
    {
        Uwy = -Uwe / (2 * Mathf.PI * R1 * capacitor);
    }

    private void calculateAlternatingCurrent()
    {
        Uwe = Uo * Mathf.Sin((1 / (float)frequency) * Time.time * (float)simulationSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        calculateAlternatingCurrent();
        calculateUwy();
        Debug.Log(Uwe + " on enter | on exit " + Uwy);
    }
}
