using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabel : MonoBehaviour, IElectricObject
{
    [SerializeField]
    private double V;
    [SerializeField]
    private double A;

    // interface that contains set voltage method;
    [SerializeField]
    private GameObject nextObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVoltage(double voltage)
    {
        this.V = voltage;
        if(nextObject != null && nextObject.GetComponent<IElectricObject>() != null)
        {
            nextObject.GetComponent<IElectricObject>().SetVoltage(V);
        }
        
    }

    public void SetAmper(double ampers)
    {
        this.A = ampers;
        if (nextObject != null && nextObject.GetComponent<IElectricObject>() != null)
        {
            nextObject.GetComponent<IElectricObject>().SetAmper(A);
        }
    }
}
