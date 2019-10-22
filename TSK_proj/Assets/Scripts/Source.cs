using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source : MonoBehaviour
{
    [SerializeField]
    private Cabel cabel;
    [SerializeField]
    private double V;
    [SerializeField]
    private double A;

    void Start()
    {
        cabel.SetVoltage(V);
        cabel.SetAmper(A);
    }
}
