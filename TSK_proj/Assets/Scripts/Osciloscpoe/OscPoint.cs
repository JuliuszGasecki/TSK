using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscPoint : MonoBehaviour
{
    private int numberOfPoitns = 20000;

    List<OscPoint> inputPoints;
    List<OscPoint> outputPoints;
    // Start is called before the first frame update
    void Start()
    {
        inputPoints = new List<OscPoint>();
        outputPoints = new List<OscPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void checkPoints()
    {
        if(inputPoints.Count > numberOfPoitns)
        {
            inputPoints.Remove(inputPoints[0]);
            outputPoints.Remove(outputPoints[0]);
        }
    }
}
